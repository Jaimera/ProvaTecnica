import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpModule } from '@angular/http';

import { CandidatoService } from '../../services/app.candidato.service';
import { TecnologiaService } from '../../services/app.tecnologia.service';
import { VagaService } from '../../services/app.vaga.service';
import { SelecaoService } from '../../services/app.selecao.service';

import { SelecoesComponent } from './selecoes.component';

describe('SelecoesComponent', () => {
  let component: SelecoesComponent;
  let fixture: ComponentFixture<SelecoesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, RouterTestingModule, HttpModule],
      declarations: [SelecoesComponent ],
      providers: [CandidatoService, VagaService, SelecaoService, TecnologiaService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelecoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
