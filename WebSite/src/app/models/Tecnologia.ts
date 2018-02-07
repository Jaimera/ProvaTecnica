export class Tecnologia {
  id: string;
  nome: string;
  selecionado: boolean = false;
}

export class TecnologiaPeso extends Tecnologia {
  peso: number;
}
