# GitHub Issue Templates for Testing

## Test Strategy Issue Template

```markdown
# Test Strategy: {Feature Name}

## Test Strategy Overview

{Summary of testing approach based on ISTQB and ISO 25010}

## ISTQB Framework Application

**Test Design Techniques Used:**
- [ ] Equivalence Partitioning
- [ ] Boundary Value Analysis
- [ ] Decision Table Testing
- [ ] State Transition Testing
- [ ] Experience-Based Testing

**Test Types Coverage:**
- [ ] Functional Testing
- [ ] Non-Functional Testing
- [ ] Structural Testing
- [ ] Change-Related Testing (Regression)

## ISO 25010 Quality Characteristics

**Priority Assessment:**
- [ ] Functional Suitability: {Critical/High/Medium/Low}
- [ ] Performance Efficiency: {Critical/High/Medium/Low}
- [ ] Compatibility: {Critical/High/Medium/Low}
- [ ] Usability: {Critical/High/Medium/Low}
- [ ] Reliability: {Critical/High/Medium/Low}
- [ ] Security: {Critical/High/Medium/Low}
- [ ] Maintainability: {Critical/High/Medium/Low}
- [ ] Portability: {Critical/High/Medium/Low}

## Quality Gates
- [ ] Entry criteria defined
- [ ] Exit criteria established
- [ ] Quality thresholds documented

## Labels
`test-strategy`, `istqb`, `iso25010`, `quality-gates`

## Estimate
{Strategic planning effort: 2-3 story points}
```

## Playwright Test Implementation Issue Template

```markdown
# Playwright Tests: {Story/Component Name}

## Test Implementation Scope
{Specific user story or component being tested}

## ISTQB Test Case Design
**Test Design Technique**: {Selected ISTQB technique}
**Test Type**: {Functional/Non-Functional/Structural/Change-Related}

## Test Cases to Implement
**Functional Tests:**
- [ ] Happy path scenarios
- [ ] Error handling validation
- [ ] Boundary value testing
- [ ] Input validation testing

**Non-Functional Tests:**
- [ ] Performance testing (response time < {threshold})
- [ ] Accessibility testing (WCAG compliance)
- [ ] Cross-browser compatibility
- [ ] Mobile responsiveness

## Playwright Implementation Tasks
- [ ] Page Object Model development
- [ ] Test fixture setup
- [ ] Test data management
- [ ] Test case implementation
- [ ] Visual regression tests
- [ ] CI/CD integration

## Acceptance Criteria
- [ ] All test cases pass
- [ ] Code coverage targets met (>80%)
- [ ] Performance thresholds validated
- [ ] Accessibility standards verified

## Labels
`playwright`, `e2e-test`, `quality-validation`

## Estimate
{Test implementation effort: 2-5 story points}
```

## Security Testing Issue Template

```markdown
# Security Tests: {Component/Feature Name}

## Security Testing Scope
{Specific security aspects being tested}

## OWASP Top 10 Coverage
**Vulnerability Categories:**
- [ ] A01: Broken Access Control
- [ ] A02: Cryptographic Failures
- [ ] A03: Injection
- [ ] A04: Insecure Design
- [ ] A05: Security Misconfiguration
- [ ] A06: Vulnerable and Outdated Components
- [ ] A07: Identification and Authentication Failures
- [ ] A08: Software and Data Integrity Failures
- [ ] A09: Security Logging and Monitoring Failures
- [ ] A10: Server-Side Request Forgery (SSRF)

## Attack Vectors to Test
**Input Validation:**
- [ ] SQL Injection testing
- [ ] Cross-Site Scripting (XSS)
- [ ] Command Injection
- [ ] Path Traversal

**Authentication & Authorization:**
- [ ] Session management
- [ ] Access control bypass
- [ ] Privilege escalation

## Testing Tools
- [ ] OWASP ZAP automated scanning
- [ ] Burp Suite manual testing
- [ ] Custom security test scripts

## Acceptance Criteria
- [ ] Zero critical vulnerabilities (CVSS 9.0+)
- [ ] Zero high vulnerabilities (CVSS 7.0-8.9)
- [ ] All input validation implemented
- [ ] Security test automation integrated

## Labels
`security-test`, `owasp`, `vulnerability-assessment`

## Estimate
{Security testing effort: 3-6 story points}
```

## Quality Assurance Issue Template

```markdown
# Quality Assurance: {Feature Name}

## Quality Validation Scope
{Overall quality validation for feature/epic}

## ISO 25010 Quality Assessment
**Quality Characteristics Validation:**
- [ ] Functional Suitability: Completeness, correctness, appropriateness
- [ ] Performance Efficiency: Time behavior, resource utilization, capacity
- [ ] Usability: Interface aesthetics, accessibility, learnability, operability
- [ ] Security: Confidentiality, integrity, authentication, authorization
- [ ] Reliability: Fault tolerance, recovery, availability
- [ ] Compatibility: Browser, device, integration compatibility
- [ ] Maintainability: Code quality, modularity, testability
- [ ] Portability: Environment adaptability, installation procedures

## Quality Gates Validation
**Entry Criteria:**
- [ ] All implementation tasks completed
- [ ] Unit tests passing
- [ ] Code review approved

**Exit Criteria:**
- [ ] All test types completed with >95% pass rate
- [ ] No critical/high severity defects
- [ ] Performance benchmarks met
- [ ] Security validation passed

## Quality Metrics
- [ ] Test coverage: {target}%
- [ ] Defect density: <{threshold} defects/KLOC
- [ ] Performance: Response time <{threshold}ms
- [ ] Accessibility: WCAG {level} compliance
- [ ] Security: Zero critical vulnerabilities

## Labels
`quality-assurance`, `iso25010`, `quality-gates`

## Estimate
{Quality validation effort: 3-5 story points}
```

## Unit Test Issue Template

```markdown
# Unit Tests: {Class/Component Name}

## Test Implementation Scope
{Specific class or component being tested}

## ISTQB Test Design
**Test Design Technique**: {Equivalence Partitioning/Boundary Value Analysis/etc.}
**Test Type**: Unit Testing - Functional

## Methods to Test
- [ ] {Method1Name}: {brief description of testing approach}
- [ ] {Method2Name}: {brief description of testing approach}
- [ ] {ErrorHandlingMethod}: Exception scenarios

## Test Cases Structure
**Positive Test Cases:**
- [ ] Valid input scenarios
- [ ] Expected behavior validation
- [ ] Return value verification

**Negative Test Cases:**
- [ ] Invalid input handling
- [ ] Null/empty parameter testing
- [ ] Exception throwing validation

**Boundary Test Cases:**
- [ ] Minimum valid values
- [ ] Maximum valid values
- [ ] Edge case scenarios

## Test Framework
- **Framework**: xUnit.net
- **Mocking**: Moq (if applicable)
- **Assertions**: FluentAssertions

## Acceptance Criteria
- [ ] >90% line coverage for the component
- [ ] >85% branch coverage
- [ ] All public methods tested
- [ ] Exception scenarios validated
- [ ] Fast execution (<100ms per test)

## Labels
`unit-test`, `xunit`, `component-test`

## Estimate
{Unit testing effort: 0.5-2 story points}
```

## Integration Test Issue Template

```markdown
# Integration Tests: {Integration Scope}

## Integration Testing Scope
{Description of components/services being integrated}

## ISTQB Test Design
**Test Design Technique**: Interface Testing
**Test Type**: Integration Testing

## Integration Points
- [ ] {Component A} ↔ {Component B}
- [ ] {Service X} ↔ {Database}
- [ ] {API} ↔ {External Service}

## Test Scenarios
**Happy Path Integration:**
- [ ] Successful data flow
- [ ] Expected responses
- [ ] Proper state management

**Error Handling Integration:**
- [ ] Network failure scenarios
- [ ] Service unavailability
- [ ] Data corruption handling

**Performance Integration:**
- [ ] Response time validation
- [ ] Throughput testing
- [ ] Resource utilization

## Test Environment
- **Database**: {SQLite/SQL Server/Test DB}
- **External Services**: {Mock/Stub services}
- **Configuration**: {Test-specific settings}

## Acceptance Criteria
- [ ] All integration points validated
- [ ] Error scenarios handled gracefully
- [ ] Performance thresholds met
- [ ] No data loss during integration
- [ ] Proper transaction management

## Labels
`integration-test`, `api-test`, `database-test`

## Estimate
{Integration testing effort: 1-3 story points}
```