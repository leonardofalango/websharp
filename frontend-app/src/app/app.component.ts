import { Component, OnInit } from '@angular/core';
import { CompleteNews } from './CompleteNews';
import { CompleteNewsService } from './complete-news.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent 
  implements OnInit
{
  data: CompleteNews[] = [];

  constructor(private service: CompleteNewsService) { }

  ngOnInit(): void 
  {
    this.update();
  }

  update()
  {
    this.service.getAll()
      .subscribe(x =>
        {
          let list: CompleteNews[] = []

          x.forEach(news =>
            {
              list.push(news)
            })
            this.data = list;
        })
  }
}
