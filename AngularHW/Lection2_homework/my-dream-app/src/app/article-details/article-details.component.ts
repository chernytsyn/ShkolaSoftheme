import { Component} from '@angular/core';
import {FormsModule} from '@angular/forms' 


export class Article {
  id:number;
  title:string;
  shortDescription:string;
}

@Component({
  selector: 'app-article-details',
  templateUrl: './article-details.component.html',
  styleUrls: ['./article-details.component.css']
})

export class ArticleDetailsComponent {

    color:string = 'black';
    heading:string = "";
    articles: Article[] = [{
      id : 1,
      title :'This is Chernytsyn article',
      shortDescription: 'This is shortDescription of the arctile'
    }];

    changeColor():void {
      this.color = this.color === 'black' ? 'gray' : 'black';
    }
 
}
