import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Article } from 'src/app/models/article.model';
import { ArticlesService } from 'src/app/services/articles.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-shopping-list',
  templateUrl: './shopping-list.component.html',
  styleUrls: ['./shopping-list.component.css']
})
export class ShoppingListComponent {
  
  articleDetails: Article = {
    id: '',
    name: '',
    price: 0,
    quantity: 0,
    eancode: 0,
  }

  
  articles: Article[] = [];
  constructor(private articleService: ArticlesService,private router: Router, private route: ActivatedRoute,private modalService:NgbModal) { }

  ngOnInit(): void {
    this.articleService.getAllArticles()
    .subscribe({
      next: (articles) => {
        this.articles = articles;
        },
      error: (response) => {
        console.log(response);
      }
    })
        
  }


  readArticle(id: string){
      if(id) {
      // call API
      this.articleService.getArticle(id)
      .subscribe(
        {
          next: (response) => 
          {
            this.articleDetails = response;
          }
        }
      )
    }
  }
}
