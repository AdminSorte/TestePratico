import axios from 'axios'
import AdicionarEditar from '../AdicionarEditar'


export default function Url(id) {
    const edit = AdicionarEditar()

    edit.values.id = id

    axios.put(`https://localhost:44387/api/v1/agenda/atualizar`, edit.values, {
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then((response) => {
        console.log(response)
    })
}