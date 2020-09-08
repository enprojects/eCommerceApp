import { NotFountComponent } from './core/not-fount/not-fount.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ShopComponent } from './shop/shop.component';
import { HomeComponent } from './home/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'test-error', component: TestErrorComponent },
  { path: 'sever-error', component: ServerErrorComponent },
  { path: 'not-found', component: NotFountComponent },
  { path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule) },
  { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule) },
  // { path: 'shop', component: ShopComponent }, // not lazy loading
  // { path: 'shop/:id', component: ProductDetailsComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' }

];

// If https://localhost:4200/gibberish this will redirect to HomeComponent screen because of path:'**' wildcard

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
