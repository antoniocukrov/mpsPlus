import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Article } from 'src/app/models/article.model';
import { ArticlesService } from 'src/app/services/articles.service';
import { NgbDatepickerModule, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css']
})
export class ArticlesListComponent implements OnInit {
    closeResult= ''; 
    addArticleRequest: Article = {
      id: '',
      name: '',
      price: 0,
      quantity: 0,
      eancode: 0,
    }
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
    addArticle() {
      this.articleService.addArticle(this.addArticleRequest)
    .subscribe({
      next: (article) => {
        window.location.reload();
      }
  
    })
  }
    updateArticle(id:string, articleDetails: Article) {
      if(id){
        this.articleService.updateArticle(id, articleDetails)
        .subscribe(
          {
            next: (response) =>
            {
              this.articleDetails = response;
              window.location.reload();
              
            }
          }
        )
      } 
    }
    deleteArticle(id: string) {
      if(id){
        this.articleService.deleteArticle(id)
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
    openAdd(content: any) {
        this.modalService.open(content, { ariaLabelledBy: 'modal-add-article' }).result
          }
    openEdit(content: any) {
            this.modalService.open(content, { ariaLabelledBy: 'modal-edit-article' }).result
          }    
    }
  
