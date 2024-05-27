import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CalculoCdbService } from '../services/calculo-cdb.service';
import { catchError, finalize } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-calculadora-cdb',
  templateUrl: './calculo-cdb.component.html',
  styleUrls: ['./calculo-cdb.component.css']
})
export class CalculoCdbComponent {
  valor: number = 0;
  meses: number = 0;
  rendimentoBruto: number = 0;
  rendimentoLiquido: number = 0;
  loading: boolean = false;

  private toastr: ToastrService;
  private calculadoraCdbService: CalculoCdbService;

  constructor(
    toastr: ToastrService,
    calculadoraCdbService: CalculoCdbService) {
    this.calculadoraCdbService = calculadoraCdbService;
    this.toastr = toastr;
  }

  calcularCDB() {
    if (!this.camposValidos()) return;

    this.loading = true;
    this.calculadoraCdbService.calcular(this.valor, this.meses)
      .pipe(
        catchError((error) => {
          this.toastr.error('', 'Erro ao calcular');
          return of(null);
        }),
        finalize(() => this.loading = false)
      )
      .subscribe((data: any) => {
        this.rendimentoBruto = data.valorBruto;
        this.rendimentoLiquido = data.valorLiquido;
      });
  }

  camposValidos(): boolean {
    if (this.meses <= 1) {
      this.toastr.warning("A quantidade de meses deve ser maior que 1");
      return false;
    }

    if (this.valor <= 0) {
      this.toastr.warning("Valor deve ser maior que 0");
      return false;
    }

    return true;
  }
}
