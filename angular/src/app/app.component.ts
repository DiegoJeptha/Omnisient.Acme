import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  sendBack:number[] = [];
  currencies = [{
    name: "Dollar",
    value: 1
  }, {
    name: "Pound",
    value: 2
  }]
  currency: number = 0;
  form: FormGroup;
  constructor(private fb: FormBuilder) {
    this.form = this.fb.group({
      money: [0, [Validators.min(0), Validators.required]],
      price: [0, [Validators.min(0), Validators.required]],
      country: [this.currency, [Validators.min(1), Validators.required]],
    })
  }


  checker() {
    var sum: number;
    var model = {
      money: this.form.controls['money'].value,
      price: this.form.controls['price'].value,
      country: this.form.controls['country'].value
    }


    if (model.money >= model.price) {
      sum = model.money - model.price;
      this.calculate(sum, model.country);
    }
  }
  calculate(sum: number, country: number) {
    var coins: number[] = [];
    
    if(country == 1) {
      coins = [1, 5, 10, 25 ];
    } else {
      coins = [ 1, 2, 10, 25];
    }

    var remainder: number = Number(sum.toFixed(2)) * 100;

    coins = coins.reverse();

    for(var i = 0; i < coins.length; i++ ) {
      let coin = coins[i];
      
      var coinTypeAmount = Math.floor(remainder/coin);
      for (var j = 0; j < coinTypeAmount; j++) {
        remainder = remainder - coin;
        this.sendBack.push(coin);
      }
    }


  }

  ngOnInit() {

  }

}
