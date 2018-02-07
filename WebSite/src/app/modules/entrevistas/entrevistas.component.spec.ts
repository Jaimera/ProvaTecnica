import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpModule } from '@angular/http';

import { EntrevistasComponent } from './entrevistas.component';
import { CandidatoService } from '../../services/app.candidato.service';
import { TecnologiaService } from '../../services/app.tecnologia.service';
import { VagaService } from '../../services/app.vaga.service';
import { SelecaoService } from '../../services/app.selecao.service';

describe('EntrevistasComponent', () => {
  let component: EntrevistasComponent;
  let fixture: ComponentFixture<EntrevistasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, RouterTestingModule, HttpModule],
      declarations: [EntrevistasComponent ],
      providers: [CandidatoService, VagaService, SelecaoService, TecnologiaService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EntrevistasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
