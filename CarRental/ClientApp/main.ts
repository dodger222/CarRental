import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';
const platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);

//to reload the application with changes in the source code
if (module.hot) {
    module.hot.accept();
    module.hot.dispose(() => {
        //before launching the application, create a new app element that replaces the old one
        const oldRootElem = document.querySelector('app');
        const newRootElem = document.createElement('app');
        oldRootElem!.parentNode!.insertBefore(newRootElem, oldRootElem);
        platform.destroy();
    })
}