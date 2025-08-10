# Quality Assurance Plan: Product Catalog Feature

## Quality Gates and Checkpoints

### Entry Criteria for Testing Phases

#### Unit Testing Phase
```xml
<!-- Criterios de entrada para testing unitario -->
<entry-criteria phase="unit-testing">
  <code-quality>
    <compilation-status>Success without errors</compilation-status>
    <static-analysis>No critical violations</static-analysis>
    <code-review>Peer review completed</code-review>
  </code-quality>
  <dependencies>
    <framework-setup>xUnit.net configured</framework-setup>
    <test-data>Sample data available</test-data>
    <mocking-tools>Moq framework ready</mocking-tools>
  </dependencies>
  <documentation>
    <requirements>Clear acceptance criteria</requirements>
    <design>Technical design approved</design>
  </documentation>
</entry-criteria>
```

#### Integration Testing Phase
```xml
<!-- Criterios de entrada para testing de integración -->
<entry-criteria phase="integration-testing">
  <prerequisites>
    <unit-tests>100% unit tests passing</unit-tests>
    <code-coverage>Minimum 80% line coverage</code-coverage>
    <components>All components individually validated</components>
  </prerequisites>
  <environment>
    <database>Test database configured</database>
    <services>Dependent services available</services>
    <configuration>Integration test environment ready</configuration>
  </environment>
</entry-criteria>
```

#### End-to-End Testing Phase
```xml
<!-- Criterios de entrada para testing E2E -->
<entry-criteria phase="e2e-testing">
  <system-readiness>
    <integration-tests>100% integration tests passing</integration-tests>
    <ui-completion>User interface stable</ui-completion>
    <deployment>Application deployed to test environment</deployment>
  </system-readiness>
  <tools>
    <playwright>Playwright framework configured</playwright>
    <test-data>End-to-end test data prepared</test-data>
    <browsers>Target browsers available</browsers>
  </tools>
</entry-criteria>
```

### Exit Criteria for Quality Gates

#### Development Complete Gate
```xml
<!-- Criterios de salida para desarrollo completo -->
<exit-criteria gate="development-complete">
  <code-quality>
    <coverage>Line coverage ≥ 80%, Branch coverage ≥ 75%</coverage>
    <defects>Zero critical, zero high severity defects</defects>
    <performance>Response time ≤ 2 seconds for critical paths</performance>
  </code-quality>
  <testing>
    <unit-tests>100% passing, ≥ 95% automation</unit-tests>
    <integration-tests>100% passing, all interfaces validated</integration-tests>
    <security-tests>SQL injection vulnerability resolved</security-tests>
  </testing>
  <documentation>
    <test-results>All test execution reports complete</test-results>
    <defect-summary>Defect closure report approved</defect-summary>
  </documentation>
</exit-criteria>
```

#### Production Ready Gate
```xml
<!-- Criterios de salida para producción -->
<exit-criteria gate="production-ready">
  <quality-validation>
    <e2e-tests>100% critical user journeys validated</e2e-tests>
    <performance-tests>Load testing passed for 100 concurrent users</performance-tests>
    <security-scan>OWASP ZAP scan with zero critical findings</security-scan>
    <accessibility>WCAG 2.1 AA compliance verified</accessibility>
  </quality-validation>
  <stakeholder-approval>
    <product-owner>Feature acceptance signed off</product-owner>
    <security-team>Security review completed</security-team>
    <operations>Deployment runbook validated</operations>
  </stakeholder-approval>
</exit-criteria>
```

### Quality Metrics and Thresholds

#### Functional Quality Metrics
```xml
<!-- Métricas de calidad funcional -->
<functional-metrics>
  <defect-density>
    <threshold>≤ 0.1 defects per function point</threshold>
    <measurement>Total defects / Function points</measurement>
    <frequency>Weekly during development</frequency>
  </defect-density>
  <test-effectiveness>
    <threshold>≥ 95% defect detection rate</threshold>
    <measurement>Defects found in testing / Total defects</measurement>
    <frequency>End of each testing phase</frequency>
  </test-effectiveness>
  <requirements-coverage>
    <threshold>100% requirements traced to tests</threshold>
    <measurement>Tested requirements / Total requirements</measurement>
    <frequency>Continuous</frequency>
  </requirements-coverage>
</functional-metrics>
```

#### Non-Functional Quality Metrics
```xml
<!-- Métricas de calidad no funcional -->
<non-functional-metrics>
  <performance>
    <response-time threshold="2000ms">Average response time for product listing</response-time>
    <throughput threshold="100rps">Requests per second under normal load</throughput>
    <resource-utilization threshold="70%">CPU/Memory usage under load</resource-utilization>
  </performance>
  <security>
    <vulnerabilities threshold="0">Critical and high severity findings</vulnerabilities>
    <input-validation threshold="100%">Input validation coverage</input-validation>
  </security>
  <usability>
    <accessibility-score threshold="95%">WCAG 2.1 AA compliance score</accessibility-score>
    <user-task-completion threshold="95%">Task completion rate in usability testing</user-task-completion>
  </usability>
</non-functional-metrics>
```

### Escalation Procedures

#### Quality Failure Escalation Matrix
```xml
<!-- Matriz de escalación por fallos de calidad -->
<escalation-matrix>
  <critical-issues>
    <description>Security vulnerabilities, system down, data corruption</description>
    <escalation-time>Immediate</escalation-time>
    <escalation-path>QA Lead → Technical Lead → Product Owner → CTO</escalation-path>
    <resolution-sla>4 hours</resolution-sla>
  </critical-issues>
  <high-issues>
    <description>Major functionality broken, performance degradation</description>
    <escalation-time>2 hours</escalation-time>
    <escalation-path>QA Lead → Technical Lead → Product Owner</escalation-path>
    <resolution-sla>24 hours</resolution-sla>
  </high-issues>
  <medium-issues>
    <description>Minor functionality issues, usability problems</description>
    <escalation-time>1 business day</escalation-time>
    <escalation-path>QA Lead → Technical Lead</escalation-path>
    <resolution-sla>3 business days</resolution-sla>
  </medium-issues>
</escalation-matrix>
```

## GitHub Issue Quality Standards

### Template Compliance Validation

#### Mandatory Template Fields
```xml
<!-- Campos obligatorios en templates de issues -->
<template-compliance>
  <test-strategy-issue>
    <required-fields>
      <field name="test-scope">Testing scope and boundaries</field>
      <field name="quality-objectives">Measurable quality goals</field>
      <field name="istqb-techniques">Applied test design techniques</field>
      <field name="iso25010-characteristics">Quality characteristics assessment</field>
      <field name="risk-assessment">Risk identification and mitigation</field>
    </required-fields>
  </test-strategy-issue>
  <test-implementation-issue>
    <required-fields>
      <field name="test-type">Unit/Integration/E2E/Performance/Security</field>
      <field name="acceptance-criteria">Clear pass/fail criteria</field>
      <field name="test-data">Required test data specification</field>
      <field name="dependencies">Blocking/dependent issues</field>
      <field name="estimation">Story points with justification</field>
    </required-fields>
  </test-implementation-issue>
</template-compliance>
```

#### Quality Validation Checklist
- [ ] **Title Clarity**: Issue title clearly describes scope and intent
- [ ] **Description Completeness**: All template sections populated
- [ ] **Acceptance Criteria**: SMART criteria (Specific, Measurable, Achievable, Relevant, Time-bound)
- [ ] **Labels Consistency**: Standard labels applied according to guidelines
- [ ] **Priority Assignment**: Risk-based priority with justification
- [ ] **Estimation Accuracy**: Effort estimation with historical data reference

### Required Field Completion Standards

#### Test Issue Field Requirements
```xml
<!-- Estándares de completitud de campos -->
<field-requirements>
  <mandatory-fields>
    <field name="title" validation="regex">^(Unit|Integration|E2E|Performance|Security) Test: .+$</field>
    <field name="description" validation="min-length">100 characters minimum</field>
    <field name="acceptance-criteria" validation="format">Given/When/Then format</field>
    <field name="test-type" validation="enum">unit-test|integration-test|e2e-test|performance-test|security-test</field>
    <field name="priority" validation="enum">critical|high|medium|low</field>
    <field name="estimation" validation="range">0.5-8 story points</field>
  </mandatory-fields>
  <optional-fields>
    <field name="dependencies">Related issue references</field>
    <field name="test-data">Test data specifications</field>
    <field name="environment">Specific environment requirements</field>
  </optional-fields>
</field-requirements>
```

#### Validation Rules
- **Title**: Must follow naming convention with test type prefix
- **Description**: Minimum 100 characters with context and rationale
- **Acceptance Criteria**: Must use Given/When/Then format for clarity
- **Labels**: Minimum 2 labels (test-type + component/priority)
- **Assignee**: Must be assigned before moving to "In Progress"
- **Milestone**: Must be associated with appropriate sprint/release

### Label Consistency Standards

#### Standardized Labeling System
```xml
<!-- Sistema estandarizado de etiquetas -->
<labeling-standards>
  <test-type-labels>
    <label name="unit-test" color="#FF6B6B">Individual component testing</label>
    <label name="integration-test" color="#4ECDC4">Component interaction testing</label>
    <label name="e2e-test" color="#45B7D1">End-to-end user journey testing</label>
    <label name="performance-test" color="#96CEB4">Load, stress, and performance testing</label>
    <label name="security-test" color="#FFEAA7">Security vulnerability testing</label>
    <label name="accessibility-test" color="#DDA0DD">WCAG compliance testing</label>
  </test-type-labels>
  <quality-labels>
    <label name="quality-gate" color="#6C5CE7">Quality checkpoint validation</label>
    <label name="iso25010" color="#FDCB6E">ISO 25010 quality characteristic</label>
    <label name="istqb-technique" color="#E17055">ISTQB test design technique</label>
    <label name="risk-based" color="#74B9FF">Risk-based testing approach</label>
  </quality-labels>
  <priority-labels>
    <label name="test-critical" color="#D63031">Must pass for release</label>
    <label name="test-high" color="#E17055">Important for quality assurance</label>
    <label name="test-medium" color="#FDCB6E">Standard testing priority</label>
    <label name="test-low" color="#00B894">Nice to have testing</label>
  </priority-labels>
  <component-labels>
    <label name="frontend-test" color="#A29BFE">UI and client-side testing</label>
    <label name="backend-test" color="#6C5CE7">Server-side and API testing</label>
    <label name="api-test" color="#81ECEC">REST API testing</label>
    <label name="database-test" color="#55A3FF">Database and data layer testing</label>
  </component-labels>
</labeling-standards>
```

#### Label Application Rules
- **Minimum Labels**: Every test issue must have at least 2 labels
- **Test Type**: Exactly one test-type label per issue
- **Priority**: Exactly one priority label per issue
- **Component**: At least one component label per issue
- **Quality Framework**: Apply quality labels when using ISTQB/ISO 25010

### Priority Assignment Standards

#### Risk-Based Priority Matrix
```xml
<!-- Matriz de prioridades basada en riesgos -->
<priority-matrix>
  <critical-priority>
    <criteria>
      <impact>System unusable, security breach, data loss</impact>
      <likelihood>High probability of occurrence</likelihood>
      <business-value>Core functionality affecting revenue</business-value>
    </criteria>
    <examples>
      <example>SQL injection vulnerability testing</example>
      <example>Core product listing functionality</example>
      <example>Payment processing validation</example>
    </examples>
    <sla>Must be completed within current sprint</sla>
  </critical-priority>
  <high-priority>
    <criteria>
      <impact>Major functionality impaired, significant UX degradation</impact>
      <likelihood>Medium to high probability</likelihood>
      <business-value>Important features affecting user satisfaction</business-value>
    </criteria>
    <examples>
      <example>Product search performance testing</example>
      <example>Mobile responsiveness validation</example>
      <example>Error handling robustness</example>
    </examples>
    <sla>Must be completed within next 2 sprints</sla>
  </high-priority>
  <medium-priority>
    <criteria>
      <impact>Minor functionality affected, limited user impact</impact>
      <likelihood>Medium probability</likelihood>
      <business-value>Supporting features enhancing user experience</business-value>
    </criteria>
    <examples>
      <example>UI consistency validation</example>
      <example>Additional browser compatibility</example>
      <example>Edge case handling</example>
    </examples>
    <sla>Can be scheduled in backlog</sla>
  </medium-priority>
  <low-priority>
    <criteria>
      <impact>Cosmetic issues, nice-to-have features</impact>
      <likelihood>Low probability of user impact</likelihood>
      <business-value>Enhancement features</business-value>
    </criteria>
    <examples>
      <example>Advanced filtering options</example>
      <example>UI animations and transitions</example>
      <example>Extended browser support</example>
    </examples>
    <sla>Future releases consideration</sla>
  </low-priority>
</priority-matrix>
```

### Value Assessment Framework

#### Business Value Calculation
```xml
<!-- Marco de evaluación de valor de negocio -->
<value-assessment>
  <business-impact-scoring>
    <revenue-impact weight="40%">
      <high score="10">Direct impact on sales/conversions</high>
      <medium score="6">Indirect impact on user engagement</medium>
      <low score="3">Minimal business impact</low>
    </revenue-impact>
    <user-experience weight="30%">
      <high score="10">Core user journey affected</high>
      <medium score="6">Secondary feature impact</medium>
      <low score="3">Minor UX enhancement</low>
    </user-experience>
    <technical-risk weight="20%">
      <high score="10">High probability of defects</high>
      <medium score="6">Medium complexity/risk</medium>
      <low score="3">Low technical risk</low>
    </technical-risk>
    <compliance-requirement weight="10%">
      <high score="10">Regulatory/security compliance</high>
      <medium score="6">Industry best practices</medium>
      <low score="3">Internal quality standards</low>
    </compliance-requirement>
  </business-impact-scoring>
  <roi-calculation>
    <formula>ROI = (Test Value Score * Defect Prevention Value) / Testing Effort</formula>
    <thresholds>
      <high-roi>&gt; 3.0</high-roi>
      <medium-roi>1.5 - 3.0</medium-roi>
      <low-roi>&lt; 1.5</low-roi>
    </thresholds>
  </roi-calculation>
</value-assessment>
```

## Dependency Validation and Management

### Circular Dependency Detection

#### Dependency Validation Rules
```xml
<!-- Reglas de validación de dependencias -->
<dependency-validation>
  <circular-dependency-check>
    <detection-algorithm>
      <step1>Build dependency graph from issue relationships</step1>
      <step2>Perform depth-first search for cycles</step2>
      <step3>Report circular dependencies with issue paths</step3>
      <step4>Flag issues for dependency restructuring</step4>
    </detection-algorithm>
    <prevention-rules>
      <rule>Unit tests cannot depend on integration tests</rule>
      <rule>Test implementation cannot depend on test planning</rule>
      <rule>E2E tests cannot depend on unit test completion</rule>
    </prevention-rules>
  </circular-dependency-check>
  <dependency-types>
    <blocks>Issue A must complete before Issue B can start</blocks>
    <relates-to>Issues are connected but not blocking</relates-to>
    <child-of>Issue is part of a larger parent issue</child-of>
    <duplicate-of>Issues represent the same work</duplicate-of>
  </dependency-types>
</dependency-validation>
```

#### Automated Dependency Monitoring
```javascript
// Ejemplo de script de validación de dependencias
const validateDependencies = (issues) => {
  const dependencyGraph = buildGraph(issues);
  const cycles = detectCycles(dependencyGraph);
  
  if (cycles.length > 0) {
    return {
      status: 'ERROR',
      message: 'Circular dependencies detected',
      cycles: cycles.map(cycle => ({
        path: cycle.join(' -> '),
        severity: 'HIGH',
        resolution: 'Restructure dependencies or remove blocking relationships'
      }))
    };
  }
  
  return { status: 'OK', message: 'No circular dependencies found' };
};
```

### Critical Path Analysis

#### Critical Path Identification
```xml
<!-- Análisis de ruta crítica -->
<critical-path-analysis>
  <methodology>
    <step1>Identify all test dependencies and durations</step1>
    <step2>Calculate earliest start and finish times</step2>
    <step3>Calculate latest start and finish times</step3>
    <step4>Identify tasks with zero slack time</step4>
    <step5>Map critical path through testing activities</step5>
  </methodology>
  <critical-path-factors>
    <test-complexity>Story point estimation</test-complexity>
    <resource-availability>Team member capacity</resource-availability>
    <environmental-dependencies>Test environment setup time</environmental-dependencies>
    <external-dependencies>Third-party service availability</external-dependencies>
  </critical-path-factors>
</critical-path-analysis>
```

#### Impact Assessment Matrix
| Dependency Type | Impact on Timeline | Mitigation Strategy |
|----------------|-------------------|-------------------|
| **Critical Path Blocker** | High (Delays entire delivery) | Parallel work streams, early identification |
| **Sequential Dependency** | Medium (Delays dependent tasks) | Task reordering, dependency removal |
| **Resource Contention** | Medium (Capacity constraints) | Resource leveling, skill sharing |
| **External Dependency** | Variable (Unpredictable delays) | Mocking, stub services, contingency plans |

### Risk Assessment Framework

#### Dependency Risk Categories
```xml
<!-- Categorías de riesgo de dependencias -->
<dependency-risks>
  <technical-risks>
    <api-changes impact="high">
      <description>Breaking changes in dependent APIs</description>
      <mitigation>Version pinning, contract testing</mitigation>
      <monitoring>API change notifications, regression testing</monitoring>
    </api-changes>
    <environment-instability impact="medium">
      <description>Test environment unavailability</description>
      <mitigation>Multiple environments, local development setup</mitigation>
      <monitoring>Environment health checks</monitoring>
    </environment-instability>
  </technical-risks>
  <resource-risks>
    <team-availability impact="high">
      <description>Key team members unavailable</description>
      <mitigation>Knowledge sharing, documentation, cross-training</mitigation>
      <monitoring>Team capacity planning</monitoring>
    </team-availability>
    <skill-gaps impact="medium">
      <description>Missing specialized testing skills</description>
      <mitigation>Training programs, external consultants</mitigation>
      <monitoring>Skill assessment, competency matrix</monitoring>
    </skill-gaps>
  </resource-risks>
</dependency-risks>
```

### Mitigation Strategies

#### Dependency Management Best Practices
```xml
<!-- Mejores prácticas para gestión de dependencias -->
<mitigation-strategies>
  <early-identification>
    <practice>Dependency mapping during planning phase</practice>
    <tool>GitHub issue relationships, dependency graphs</tool>
    <frequency>Weekly dependency review meetings</frequency>
  </early-identification>
  <parallel-development>
    <practice>Identify opportunities for concurrent work</practice>
    <example>UI tests while backend API under development</example>
    <technique>Mock services, test doubles, contract testing</technique>
  </parallel-development>
  <contingency-planning>
    <practice>Alternative approaches for blocked dependencies</practice>
    <example>Offline testing when external services unavailable</example>
    <documentation>Contingency procedures documented per dependency</documentation>
  </contingency-planning>
</mitigation-strategies>
```

## Estimation Accuracy and Review

### Historical Data Analysis

#### Estimation Baseline Establishment
```xml
<!-- Establecimiento de línea base para estimaciones -->
<estimation-baseline>
  <historical-analysis>
    <data-sources>
      <previous-projects>Similar e-commerce testing projects</previous-projects>
      <team-velocity>Current team historical velocity</team-velocity>
      <industry-benchmarks>ISTQB and testing industry standards</industry-benchmarks>
    </data-sources>
    <metrics-collection>
      <actual-vs-estimated>Track variance for estimation improvement</actual-vs-estimated>
      <complexity-factors>Identify factors affecting estimation accuracy</complexity-factors>
      <team-productivity>Measure productivity trends over time</team-productivity>
    </metrics-collection>
  </historical-analysis>
  <estimation-guidelines>
    <unit-test-effort>0.5-1 story point per simple component</unit-test-effort>
    <integration-test-effort>1-2 story points per interface</integration-test-effort>
    <e2e-test-effort>2-3 story points per user workflow</e2e-test-effort>
    <performance-test-effort>3-5 story points per performance requirement</performance-test-effort>
    <security-test-effort>2-4 story points per security requirement</security-test-effort>
  </estimation-guidelines>
</estimation-baseline>
```

### Technical Lead Review Process

#### Expert Validation Framework
```xml
<!-- Marco de validación por expertos técnicos -->
<technical-review-process>
  <review-criteria>
    <technical-complexity>
      <assessment>Evaluate technical challenges and unknowns</assessment>
      <adjustment>Apply complexity multipliers (1.2x for medium, 1.5x for high)</adjustment>
    </technical-complexity>
    <team-expertise>
      <assessment>Match task complexity with team skill level</assessment>
      <adjustment>Add learning curve buffer for new technologies</adjustment>
    </team-expertise>
    <integration-complexity>
      <assessment>Evaluate inter-component dependencies</assessment>
      <adjustment>Add integration overhead for complex interfaces</adjustment>
    </integration-complexity>
  </review-criteria>
  <review-checklist>
    <item>Are all technical dependencies identified?</item>
    <item>Is the complexity assessment realistic?</item>
    <item>Are there any missing tasks or edge cases?</item>
    <item>Is the estimation consistent with similar past work?</item>
    <item>Are there adequate buffers for unknowns?</item>
  </review-checklist>
</technical-review-process>
```

#### Review Outcome Documentation
```xml
<!-- Documentación de resultados de revisión -->
<review-outcomes>
  <estimation-adjustments>
    <upward-adjustments>
      <reason>Higher complexity than initially assessed</reason>
      <factor>1.2x - 2.0x multiplier</factor>
      <examples>Complex security testing, performance optimization</examples>
    </upward-adjustments>
    <downward-adjustments>
      <reason>Existing tools/framework reduce effort</reason>
      <factor>0.8x - 0.9x multiplier</factor>
      <examples>Automated test generation, reusable components</examples>
    </downward-adjustments>
  </estimation-adjustments>
  <confidence-levels>
    <high-confidence>90-95% accuracy expected</high-confidence>
    <medium-confidence>80-90% accuracy expected</medium-confidence>
    <low-confidence>70-80% accuracy expected, requires spike</low-confidence>
  </confidence-levels>
</review-outcomes>
```

### Risk Buffer Allocation

#### Uncertainty Management
```xml
<!-- Gestión de incertidumbre en estimaciones -->
<risk-buffer-strategy>
  <buffer-allocation-rules>
    <low-risk-tasks buffer="10%">
      <criteria>Well-understood technology, clear requirements</criteria>
      <example>Standard unit tests for CRUD operations</example>
    </low-risk-tasks>
    <medium-risk-tasks buffer="25%">
      <criteria>Some unknowns, moderate complexity</criteria>
      <example>Integration testing with third-party APIs</example>
    </medium-risk-tasks>
    <high-risk-tasks buffer="50%">
      <criteria>Significant unknowns, high technical complexity</criteria>
      <example>Performance testing with undefined load patterns</example>
    </high-risk-tasks>
  </buffer-allocation-rules>
  <buffer-tracking>
    <utilization-monitoring>Track actual buffer usage vs. allocated</utilization-monitoring>
    <learning-feedback>Use buffer utilization to improve future estimates</learning-feedback>
    <reallocation-triggers>When to redistribute unused buffers</reallocation-triggers>
  </buffer-tracking>
</risk-buffer-strategy>
```

### Estimate Refinement Process

#### Continuous Improvement Framework
```xml
<!-- Marco de mejora continua para estimaciones -->
<refinement-process>
  <retrospective-analysis>
    <frequency>End of each sprint and project</frequency>
    <metrics-review>
      <estimation-accuracy>Actual vs. estimated effort</estimation-accuracy>
      <variance-analysis>Identify patterns in over/under estimation</variance-analysis>
      <complexity-calibration>Adjust complexity assessment criteria</complexity-calibration>
    </metrics-review>
  </retrospective-analysis>
  <improvement-actions>
    <calibration-sessions>
      <purpose>Team alignment on estimation standards</purpose>
      <frequency>Monthly</frequency>
      <activities>Planning poker recalibration, historical analysis review</activities>
    </calibration-sessions>
    <estimation-templates>
      <purpose>Standardize estimation approach</purpose>
      <content>Checklists, complexity factors, historical benchmarks</content>
      <maintenance>Regular updates based on retrospective insights</maintenance>
    </estimation-templates>
  </improvement-actions>
</refinement-process>
```

## Quality Metrics Dashboard

### Real-Time Quality Monitoring
```xml
<!-- Dashboard de monitoreo de calidad en tiempo real -->
<quality-dashboard>
  <test-execution-metrics>
    <pass-rate threshold="95%">Percentage of tests passing</pass-rate>
    <execution-time trend="decreasing">Time to execute full test suite</execution-time>
    <automation-coverage>Percentage of tests automated</automation-coverage>
  </test-execution-metrics>
  <defect-metrics>
    <defect-discovery-rate>Defects found per day/week</defect-discovery-rate>
    <defect-resolution-time>Average time to fix defects</defect-resolution-time>
    <defect-escape-rate>Defects found in production</defect-escape-rate>
  </defect-metrics>
  <coverage-metrics>
    <code-coverage>Line/branch coverage percentages</code-coverage>
    <requirements-coverage>Tested vs. total requirements</requirements-coverage>
    <risk-coverage>High-risk scenarios tested</risk-coverage>
  </coverage-metrics>
</quality-dashboard>
```