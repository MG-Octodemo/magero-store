/**
 * Funcionalidad AJAX para filtros de productos
 * Permite filtrar productos sin recargar la página
 */

document.addEventListener('DOMContentLoaded', function() {
    // Elementos del DOM
    const priceFilterForm = document.getElementById('priceFilterForm');
    const applyFiltersBtn = document.getElementById('applyFiltersBtn');
    const clearFiltersBtn = document.getElementById('clearFiltersBtn');
    const productList = document.getElementById('productList');
    const loadingIndicator = document.getElementById('loading-indicator');
    const customPriceRange = document.getElementById('customPriceRange');
    const priceRangeRadios = document.querySelectorAll('input[name="priceRange"]');
    const customRadio = document.getElementById('priceCustom');

    // Validar que los elementos existen
    if (!priceFilterForm || !applyFiltersBtn || !clearFiltersBtn) {
        console.warn('Elementos del filtro de precios no encontrados');
        return;
    }

    /**
     * Muestra u oculta el rango de precios personalizado
     */
    function toggleCustomPriceRange() {
        const isCustomSelected = customRadio.checked;
        if (isCustomSelected) {
            customPriceRange.classList.remove('d-none');
        } else {
            customPriceRange.classList.add('d-none');
        }
    }

    /**
     * Obtiene los datos del formulario de filtros
     */
    function getFilterData() {
        const formData = new FormData(priceFilterForm);
        const selectedPriceRange = formData.get('priceRange');
        
        return {
            searchTerm: formData.get('searchTerm') || '',
            priceRange: selectedPriceRange || '0',
            minPrice: selectedPriceRange === '6' ? formData.get('minPrice') : null,
            maxPrice: selectedPriceRange === '6' ? formData.get('maxPrice') : null
        };
    }

    /**
     * Valida los precios personalizados
     */
    function validateCustomPrices(minPrice, maxPrice) {
        const errors = [];
        
        if (minPrice !== null && minPrice < 0) {
            errors.push('El precio mínimo no puede ser negativo');
        }
        
        if (maxPrice !== null && maxPrice < 0) {
            errors.push('El precio máximo no puede ser negativo');
        }
        
        if (minPrice !== null && maxPrice !== null && parseFloat(minPrice) > parseFloat(maxPrice)) {
            errors.push('El precio mínimo no puede ser mayor que el precio máximo');
        }
        
        return errors;
    }

    /**
     * Muestra errores de validación
     */
    function showValidationErrors(errors) {
        // Remover alertas anteriores
        const existingAlerts = document.querySelectorAll('.price-filter-alert');
        existingAlerts.forEach(alert => alert.remove());

        if (errors.length > 0) {
            const alertDiv = document.createElement('div');
            alertDiv.className = 'alert alert-danger alert-dismissible fade show price-filter-alert';
            alertDiv.innerHTML = `
                <strong>Error de validación:</strong>
                <ul class="mb-0">
                    ${errors.map(error => `<li>${error}</li>`).join('')}
                </ul>
                <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            `;
            
            priceFilterForm.insertBefore(alertDiv, priceFilterForm.firstChild);
        }
    }

    /**
     * Muestra el indicador de carga
     */
    function showLoading() {
        if (loadingIndicator) {
            loadingIndicator.classList.remove('d-none');
        }
        if (productList) {
            productList.style.opacity = '0.5';
        }
    }

    /**
     * Oculta el indicador de carga
     */
    function hideLoading() {
        if (loadingIndicator) {
            loadingIndicator.classList.add('d-none');
        }
        if (productList) {
            productList.style.opacity = '1';
        }
    }

    /**
     * Aplica los filtros mediante AJAX
     */
    async function applyFilters() {
        try {
            const filterData = getFilterData();
            
            // Validar precios personalizados si están seleccionados
            if (filterData.priceRange === '6') { // Custom
                const errors = validateCustomPrices(filterData.minPrice, filterData.maxPrice);
                if (errors.length > 0) {
                    showValidationErrors(errors);
                    return;
                }
            }

            // Limpiar errores anteriores
            showValidationErrors([]);
            
            // Mostrar indicador de carga
            showLoading();

            // Crear FormData para la petición POST
            const formData = new FormData();
            formData.append('searchTerm', filterData.searchTerm);
            formData.append('priceRange', filterData.priceRange);
            if (filterData.minPrice) formData.append('minPrice', filterData.minPrice);
            if (filterData.maxPrice) formData.append('maxPrice', filterData.maxPrice);

            // Realizar petición AJAX
            const response = await fetch('/Products/FilterProducts', {
                method: 'POST',
                body: formData,
                headers: {
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value || ''
                }
            });

            if (!response.ok) {
                throw new Error(`Error ${response.status}: ${response.statusText}`);
            }

            const html = await response.text();
            
            // Actualizar la lista de productos
            if (productList) {
                productList.innerHTML = html;
            }

            // Actualizar URL sin recargar la página
            updateUrlParams(filterData);

        } catch (error) {
            console.error('Error al aplicar filtros:', error);
            showValidationErrors(['Error al cargar los productos. Por favor, intente nuevamente.']);
        } finally {
            hideLoading();
        }
    }

    /**
     * Actualiza los parámetros de la URL
     */
    function updateUrlParams(filterData) {
        const url = new URL(window.location);
        
        // Limpiar parámetros anteriores
        url.searchParams.delete('searchTerm');
        url.searchParams.delete('priceRange');
        url.searchParams.delete('minPrice');
        url.searchParams.delete('maxPrice');

        // Agregar nuevos parámetros
        if (filterData.searchTerm) {
            url.searchParams.set('searchTerm', filterData.searchTerm);
        }
        if (filterData.priceRange !== '0') {
            url.searchParams.set('priceRange', filterData.priceRange);
        }
        if (filterData.minPrice) {
            url.searchParams.set('minPrice', filterData.minPrice);
        }
        if (filterData.maxPrice) {
            url.searchParams.set('maxPrice', filterData.maxPrice);
        }

        // Actualizar URL
        window.history.pushState({}, '', url);
    }

    /**
     * Limpia todos los filtros
     */
    function clearFilters() {
        // Resetear formulario
        priceFilterForm.reset();
        
        // Seleccionar "Todos los precios"
        const allPricesRadio = document.getElementById('priceAll');
        if (allPricesRadio) {
            allPricesRadio.checked = true;
        }
        
        // Ocultar rango personalizado
        toggleCustomPriceRange();
        
        // Limpiar errores
        showValidationErrors([]);
        
        // Aplicar filtros (que ahora estarán limpios)
        applyFilters();
    }

    // Event Listeners
    priceRangeRadios.forEach(radio => {
        radio.addEventListener('change', toggleCustomPriceRange);
    });

    applyFiltersBtn.addEventListener('click', applyFilters);
    clearFiltersBtn.addEventListener('click', clearFilters);

    // Event listener para el botón de limpiar desde la página de resultados
    document.addEventListener('click', function(e) {
        if (e.target && e.target.id === 'clearFiltersFromResults') {
            clearFilters();
        }
    });

    // Aplicar filtros automáticamente cuando cambian los rangos predefinidos
    priceRangeRadios.forEach(radio => {
        if (radio.id !== 'priceCustom') {
            radio.addEventListener('change', function() {
                setTimeout(applyFilters, 100); // Pequeño delay para asegurar que el DOM se actualice
            });
        }
    });

    // Aplicar filtros al presionar Enter en los campos de precio personalizado
    const minPriceInput = document.getElementById('minPrice');
    const maxPriceInput = document.getElementById('maxPrice');
    
    [minPriceInput, maxPriceInput].forEach(input => {
        if (input) {
            input.addEventListener('keypress', function(e) {
                if (e.key === 'Enter') {
                    e.preventDefault();
                    if (customRadio.checked) {
                        applyFilters();
                    }
                }
            });
        }
    });

    // Inicializar el estado del rango personalizado
    toggleCustomPriceRange();
});