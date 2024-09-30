# Flow Chart

```mermaid
%%{
  init: {
    'theme': 'base',
    'themeVariables': {
      'primaryColor': '#BB2528',
      'primaryTextColor': '#fff',
      'primaryBorderColor': '#7C0000',
      'lineColor': '#F8B229',
      'secondaryColor': '#006100',
      'tertiaryColor': '#fff'
    }
  }
}%%
graph TD;
  A[Login Panel] == Interact with ==> B[/Database/]
  C[Main Panel] == (at starting) Loads ==> A
  C == Click to "new button" ==> D[New Panel

                                    - Clear text panel
                                    - Select and download the required document
                                    - Show the document
                                    - Reset disabled buttons
                                    - Disable "load buttons" and "historic buttons"]
  D == Retrieve documents from ==> E[/Database/]
  C == Click to "save buttons" ==> F[/ - Clear text panel
                                       - Save html Document
                                       - Move html Document to "saved document folder"
                                       - Reset disabled buttons
                                       - Disable "send button"
                                       - Reset the Panel
                                       - Open a message box to show ("saved successfully")/]
  C == Click to "load button" ==> G[Load panel

                                    - Clear text panel
                                    - Select and show the required document from "saved document folder"
                                    - Reset disabled buttons
                                    - Disable "new button" and "historic button"]
  C == Click to "historic button" ==> H[Historic panel

                                        - Clear text panel
                                        - Select and show the required document from "historic forlder"
                                        - Reset disabled buttons
                                        - Disable "save button" and "send button"]
 C == Click to "send button" ==> I[/ - Clear text panel
                                     - Send document to database
                                     - Send mails to addressees
                                     - Move the actual document to "historic folder"/]
 I == Comunicate with ==> [/Database/]
 C == Click to "reset button" ==> K[/ - Clear text panel
                                      - Reset disabled buttons/]
```
