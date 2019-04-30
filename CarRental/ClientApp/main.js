import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';
var platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);
//to reload the application with changes in the source code
if (module.hot) {
    module.hot.accept();
    module.hot.dispose(function () {
        //before launching the application, create a new app element that replaces the old one
        var oldRootElem = document.querySelector('app');
        var newRootElem = document.createElement('app');
        oldRootElem.parentNode.insertBefore(newRootElem, oldRootElem);
        platform.destroy();
    });
}
//# sourceMappingURL=main.js.map