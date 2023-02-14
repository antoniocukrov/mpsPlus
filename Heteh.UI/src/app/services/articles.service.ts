import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Article } from '../models/article.model';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  constructor(private http: HttpClient) { }

  getAllArticles(): Observable<Article[]> {
    return this.http.get<Article[]>('https://localhost:7294/api/articles');
  }

  addArticle(addArticleRequest: Article): Observable<Article> {
    addArticleRequest.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Article>('https://localhost:7294/api/articles', addArticleRequest);
  }

  getArticle(id: string): Observable<Article>{
    return this.http.get<Article>('https://localhost:7294/api/articles/' + id);
  }

  updateArticle(id: string, updateArticleRequest: Article): Observable<Article>{
    return this.http.put<Article>('https://localhost:7294/api/articles/' + id, updateArticleRequest);
  }

  deleteArticle(id: string): Observable<Article> {
    return this.http.delete<Article>('https://localhost:7294/api/articles/' + id);
  }
}
