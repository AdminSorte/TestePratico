import Vue from 'vue';
import Toasted from 'vue-toasted';

Vue.use(Toasted);

Vue.toasted.register('error',
  (payload) => !payload.mensagem ? 'Oops.. Algo deu errado!' : ('Oops.. ' + payload.mensagem),
  {
    type: 'error',
    duration: 5000,
    keepOnHover: true
  }
);

Vue.toasted.register('success',
  (payload) => !payload.mensagem ? 'Sucesso ... A operação foi realizada' : payload.mensagem,
  {
    type: 'success',
    duration: 5000,
    keepOnHover: true
  }
);
