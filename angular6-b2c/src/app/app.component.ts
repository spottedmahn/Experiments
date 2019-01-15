import { Component, OnInit } from '@angular/core';
import { Logger, UserAgentApplication, LogLevel } from 'msal';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'app';

  private applicationConfig = {
    clientID: 'd0a1dacb-a76f-4cd3-8055-d387a7d821ca',
    authority: "https://login.microsoftonline.com/tfp/spottedmahnb2c.onmicrosoft.com/B2C_1_Unified-Angular-6",
    //b2cScopes: ["https://fabrikamb2c.onmicrosoft.com/demoapi/demo.read"],
    //webApi: 'https://fabrikamb2chello.azurewebsites.net/hello',
  };

  private msalLogger = new Logger(this.loggerCallback, { level: LogLevel.Verbose }); // level and correlationId are optional parameters.
  //Logger has other optional parameters like piiLoggingEnabled which can be assigned as shown aabove. Please refer to the docs to see the full list and their default values.

  private loggerCallback(logLevel, message, piiLoggingEnabled) {
    console.debug('msal logging', message);
  }
  private userAgentApplication = new UserAgentApplication(this.applicationConfig.clientID, this.applicationConfig.authority, this.authCallback, { logger: this.msalLogger, cacheLocation: 'localStorage' }); //logger and cacheLocation are optional parameters.
  //userAgentApplication has other optional parameters like redirectUri which can be assigned as shown above.Please refer to the docs to see the full list and their default values.

  private authCallback(errorDesc, token, error, tokenType) {
    if (token) {
      console.debug('token received', token);
    }
    else {
      console.error(error + ":" + errorDesc);
    }
  }

  get displayName(): string {
    let user = this.userAgentApplication.getUser();

    if (!user)
      return 'please login';

    return user.name;
  }

  ngOnInit(): void {

    //not working w/ angular 6
    //this.login();
  }

  login(){
    if (!this.userAgentApplication.getUser()) {
      console.debug('user not signed in, redirecting');
      this.userAgentApplication.loginRedirect();
    }
  }

  logout(){
    this.userAgentApplication.logout();
    console.info('logger the user out');
    this.login();
  }


}
