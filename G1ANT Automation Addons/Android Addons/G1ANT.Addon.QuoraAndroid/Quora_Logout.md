# quora.logout

## Syntax

```G1ANT
quora.logout
```

## Description

This command opens an instance of a chosen web browser and navigates to a default URL address.
| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
| `loginid` | [text] |yes  |    |Enter loginid of your quora account |
| `password` | [text] |yes   |    |Enter password of your quora account |
| `result` | [variable] |no |  [♥result] |Name of a variable where the command's result will be stored |
| `nowait` | [bool] | no |true  | By default, waits until the webpage fully loads |
| `waitfornewwindow` | [bool]  | no | true | If set to true, the command should wait for a new window to appear after clicking the specified element |
| `timeout` | [timespan]  | no | [♥timeoutcommand] | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
| `errorcall` | [procedure]| no |     | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
| `errorjump` | [lable]| no |     | Name of the label to jump to when the command throws an exception or when a given timeout expires |
| `errormessage` | [text]| no |     | A message that will be shown in case the command throws an exception or when a given timeout expires, and no errorjump argument is specified |
| `errorresult` | [variable]| no |     | Name of a variable that will store the returned exception. The variable will be of error structure |
For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage`and `errorresult` arguments, see `Common Arguments` page.

## Example

This simple script opens chrome, searches for Quora's webpage and login into your account by credentials that have been provided by you. Then wait for 2 seconds and logout of your Quora account.

```G1ANT
quora.open browse chrome
quora.login loginid <Enter your loginid here> password <Enter your password here>
delay 2
quora.logout
```