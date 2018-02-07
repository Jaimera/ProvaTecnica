import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpModule } from '@angular/http';


import { TecnologiaService } from '../../services/app.tecnologia.service';
import { TecnologiasComponent } from './tecnologias.component';

describe('TecnologiasComponent', () => {
  let component: TecnologiasComponent;
  let fixture: ComponentFixture<TecnologiasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, RouterTestingModule, HttpModule],
      declarations: [TecnologiasComponent ],
      providers: [TecnologiaService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TecnologiasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
