import { Routes } from "@angular/router";


export const APP_ROUTES: Routes = [
  {
   path: '',
   redirectTo: '/users',
   pathMatch: 'full'
  },
  {
    path: 'users',
    data: { preload: true },
    loadChildren: 'app/modules/users/users.module#UsersModule'
  },
  {
    path: 'tecnologias',
    loadChildren: 'app/modules/tecnologias/tecnologias.module#TecnologiasModule'
  },
  {
    path: 'vagas',
    loadChildren: 'app/modules/vagas/vagas.module#VagasModule'
  },
  {
    path: 'entrevistas',
    loadChildren: 'app/modules/entrevistas/entrevistas.module#EntrevistasModule'
  },
  {
    path: 'selecoes',
    loadChildren: 'app/modules/selecoes/selecoes.module#SelecoesModule'
  }
  ,
  {
   path: '**',
   redirectTo: '/users'
  }
];
