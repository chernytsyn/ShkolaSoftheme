import { Component} from '@angular/core';
import {FormsModule} from '@angular/forms' 

@Component({
  selector: 'app-article-details',
  templateUrl: './article-details.component.html',
  styleUrls: ['./article-details.component.css']
})

export class ArticleDetailsComponent {

    color:string = 'black';
    heading:string = "";

    id:number = 1;
    title:string = 'This is Chernytsyn article';
    shortDescription:string = 'This is shortDescription of the arctile';

    changeColor():void {
      if (this.color=='black')
        {
          this.color='gray';
        }
      else {
        this.color='black'
      }
      }
    }
 

