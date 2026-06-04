---
emoji: 📚
description: Daily documentation sync for recent code changes
on:
  schedule: daily
permissions:
  contents: read
  issues: read
  pull-requests: read
strict: true
network:
  allowed: [defaults, github]
tools:
  github:
    mode: gh-proxy
    toolsets: [default]
safe-outputs:
  create-pull-request:
    title-prefix: "[docs-sync] "
    labels: [documentation, automation]
    draft: true
    if-no-changes: ignore
    allowed-files:
      - "README.md"
      - "ScriptPruebas.md"
      - "docs/**/*.md"
---

# Daily Documentation Sync

## Task

Review code changes merged in the last day and identify repository documentation that is now out of sync.

Prioritize user-facing and contributor-facing docs, especially:
- `README.md`
- `ScriptPruebas.md`
- markdown files under `docs/`

Make only documentation edits needed to reflect current behavior and implementation.
Do not modify source code.

When proposing edits:
- keep existing tone and structure
- avoid speculative or unnecessary rewrites
- include concise, accurate updates tied to observed code changes

## Safe Outputs

- Open a pull request using `create-pull-request` when documentation updates are needed.
- Call `noop` with a short reason when no documentation updates are required.
