# Quick Start Guide - Test Planning & QA Documentation

## 🚀 Getting Started in 5 Minutes

### For QA Engineers

#### Creating Test Documentation for a New Feature

1. **Create Feature Directory**
   ```bash
   mkdir -p docs/ways-of-work/plan/your-epic/your-feature
   ```

2. **Copy Templates**
   ```bash
   cp docs/ways-of-work/plan/sample-epic/sample-feature/*.md \
      docs/ways-of-work/plan/your-epic/your-feature/
   ```

3. **Fill Out Templates** (in order)
   - `test-strategy.md` - Overall testing approach
   - `test-issues-checklist.md` - Task breakdown
   - `qa-plan.md` - Quality gates and metrics

#### Creating GitHub Issues

1. Go to repository Issues → Click **New Issue**
2. Choose template:
   - **Test Strategy** - For high-level test planning
   - **Playwright Test Implementation** - For E2E tests
   - **Quality Assurance** - For quality validation

3. Fill template fields and submit

### For Product Managers

#### Understanding Quality Standards

- **ISTQB**: International software testing best practices
- **ISO 25010**: Quality characteristics (8 key areas):
  - Functional Suitability
  - Performance Efficiency
  - Compatibility
  - Usability
  - Reliability
  - Security
  - Maintainability
  - Portability

#### Quality Gates

**Entry Criteria** - Requirements before testing can start  
**Exit Criteria** - Standards before release

Key metrics:
- Test Pass Rate: ≥ 95%
- Code Coverage: ≥ 80%
- Critical Defects: 0
- Performance: Response time targets met

### For Developers

#### Test Coverage Targets

- **Code Coverage**: 80% minimum overall
- **Branch Coverage**: 90% for critical paths
- **Acceptance Criteria**: 100% validation

#### Test Types You'll Encounter

- **Unit Tests**: Component-level (0.5-1 SP)
- **Integration Tests**: Interface testing (1-2 SP)
- **E2E Tests**: Full workflows (2-3 SP)
- **Performance Tests**: Load/stress testing (3-5 SP)

---

## 📋 Common Tasks

### Task: Create Test Strategy for New Feature

1. **Copy template**
   ```bash
   cp docs/ways-of-work/plan/sample-epic/sample-feature/test-strategy.md \
      docs/ways-of-work/plan/my-epic/my-feature/
   ```

2. **Fill required sections**:
   - [ ] Test Strategy Overview
   - [ ] ISTQB Framework Application
   - [ ] ISO 25010 Quality Assessment
   - [ ] Test Coverage Targets
   - [ ] Risk Assessment

3. **Review with team** and get approval

### Task: Create Test Issues from Checklist

1. Open `test-issues-checklist.md`
2. For each unchecked item:
   - Create GitHub issue using appropriate template
   - Add labels from checklist
   - Set priority
   - Add estimate
   - Link dependencies
3. Check off item in checklist

### Task: Validate Quality Gates

1. Open `qa-plan.md`
2. Review Entry Criteria - can testing start?
3. During testing, track metrics
4. Before release, verify Exit Criteria
5. Get sign-off from stakeholders

---

## 🏷️ Label Quick Reference

### Test Types
```
unit-test
integration-test
e2e-test
performance-test
security-test
accessibility-test
regression-test
```

### Priority
```
test-critical   - Must pass for release
test-high       - Important for quality
test-medium     - Desirable validation
test-low        - Nice to have
```

### Components
```
frontend-test
backend-test
api-test
database-test
```

### Quality Framework
```
istqb
iso25010
quality-gates
playwright
```

---

## 📊 Key Metrics at a Glance

| Metric | Target | Critical Threshold |
|--------|--------|-------------------|
| Test Pass Rate | ≥ 95% | < 90% |
| Code Coverage | ≥ 80% | < 70% |
| Critical Defects | 0 | > 0 |
| High Defects | 0 | > 2 |
| Response Time (95th) | < 200ms | > 500ms |
| WCAG Compliance | Level AA | < Level A |

---

## 🔗 Quick Links

- [Full README](README.md) - Comprehensive guide
- [Standards Validation](STANDARDS-VALIDATION.md) - Compliance checklist
- [Test Strategy Template](plan/sample-epic/sample-feature/test-strategy.md)
- [Test Issues Checklist](plan/sample-epic/sample-feature/test-issues-checklist.md)
- [QA Plan Template](plan/sample-epic/sample-feature/qa-plan.md)

---

## ❓ FAQ

**Q: Which template do I use first?**  
A: Start with `test-strategy.md`, then use `test-issues-checklist.md` to create issues, then `qa-plan.md` for quality gates.

**Q: Do I need to fill out every section?**  
A: Fill out sections relevant to your feature. Use "N/A" for non-applicable sections.

**Q: How do I prioritize tests?**  
A: Use risk-based approach: Critical business paths → High-risk scenarios → Standard scenarios → Edge cases

**Q: What's the difference between entry and exit criteria?**  
A: Entry = prerequisites before starting. Exit = standards before moving forward/releasing.

**Q: Can I customize the templates?**  
A: Yes! Templates are starting points. Adapt to your project needs while maintaining key ISTQB/ISO 25010 elements.

---

## 🆘 Need Help?

1. Check [README.md](README.md) for detailed guidance
2. Review [STANDARDS-VALIDATION.md](STANDARDS-VALIDATION.md) for compliance details
3. Consult with QA Lead or Test Manager
4. Reference ISTQB/ISO 25010 official documentation

---

**Last Updated**: 2025-10-28  
**Quick Reference Version**: 1.0
