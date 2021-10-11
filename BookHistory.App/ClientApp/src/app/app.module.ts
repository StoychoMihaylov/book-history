import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CreateBook } from './create-book/create-book.component';
import { EditBook } from './edit-book/edit-book.component';
import { BookDetails } from './book-details/book-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CreateBook,
    EditBook,
    BookDetails
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'create-book', component: CreateBook },
      { path: 'edit-book/:id', component: EditBook },
      { path: 'book-details/:id', component: BookDetails }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
