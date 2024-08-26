# Template Samples

This folder contains the sample projects used for the templates.

## Template Key Words

| Key | Description | Status |
|-|-|-|
| `CURRENT_YEAR` | Current year to replace with | _Coming Soon_ |
| `COMPANY_NAME` | Company name (if provided) | _Coming Soon_ |
| `SampleApp` | Root Namespace | Active |

## Updating Templates

1. Update the sample app first
2. Copy/past into the template folder
3. `.csproj` - Replace `net8.0` with `TARGET_FRAMEWORK`
4. Keep: `SampleApp` as the base namespace
   1. This will get replaced via the `template.json`
5. Run the unit tester

## Features to Add

* [ ] ViewModel
* [ ] SplitView App
