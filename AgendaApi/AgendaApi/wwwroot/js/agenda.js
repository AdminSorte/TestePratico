const uri = 'api/AgendaItems';
let agendas = [];

function getItems() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Não foi possivel encontrar as agendas', error));
    document.getElementById('search-Item').value = "";
}

function searchItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItemsSearch(data))
        .catch(error => console.error('Não foi possivel pesquisar as agendas.', error));
}

function addItem() {
    const addNameTextbox = document.getElementById('add-name');
    const addDescriptionTextbox = document.getElementById('add-description');

    const item = {
      isComplete: false,
      name: addNameTextbox.value.trim(),
      description: addDescriptionTextbox.value.trim()
    };

  fetch(uri, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => {
      getItems();
      addNameTextbox.value = '';
      addDescriptionTextbox.value = '';
    })
    .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    if (document.getElementById('search-Item').value === "") {
        fetch(`${uri}/${id}`, {
            method: 'DELETE'
        })
            .then(() => getItems())
            .catch(error => console.error('Unable to delete item.', error));
    }
    else {
        fetch(`${uri}/${id}`, {
            method: 'DELETE'
        })
            .then(() => searchItems())
            .catch(error => console.error('Unable to delete item.', error));
    }
}

function displayEditForm(id) {
  const item = agendas.find(item => item.id === id);
  
  document.getElementById('edit-name').value = item.name;
  document.getElementById('edit-description').value = item.description;
  document.getElementById('edit-id').value = item.id;
  document.getElementById('edit-isComplete').checked = item.isComplete;
  document.getElementById('editForm').style.display = 'block';
}

function displayDivForm(divid) {
    var x = document.getElementById(divid);
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

function updateItem() {
  const itemId = document.getElementById('edit-id').value;
  const item = {
    id: parseInt(itemId, 10),
    isComplete: document.getElementById('edit-isComplete').checked,
    name: document.getElementById('edit-name').value.trim(),
    description: document.getElementById('edit-description').value.trim()
  };

  fetch(`${uri}/${itemId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to update item.', error));

   displayDivForm('editForm');

  return false;
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'agenda' : 'agendas';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
  const tBody = document.getElementById('agendas');
  tBody.innerHTML = '';

  _displayCount(data.length);

    const imgEdit = document.createElement('input');
    const imgTrash = document.createElement('input');

  data.forEach(item => {
    let isCompleteCheckbox = document.createElement('input');
    isCompleteCheckbox.type = 'checkbox';
    isCompleteCheckbox.disabled = true;
    isCompleteCheckbox.checked = item.isComplete;

    let editButton = imgEdit.cloneNode(false);
      editButton.setAttribute('src', `/IMG/edit.png`);
      editButton.setAttribute('style', `height:20px; width:20px;`);
      editButton.setAttribute('type', `image`);
      editButton.setAttribute('class', `visible`);
    editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

    let deleteButton = imgTrash.cloneNode(false);
    deleteButton.setAttribute('src', `/IMG/trash.png`);
    deleteButton.setAttribute('style', `height:20px; width:20px;`);
    deleteButton.setAttribute('type', `image`);
    deleteButton.setAttribute('class', `visible`);
    deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

    let tr = tBody.insertRow();
    
    let td1 = tr.insertCell(0);
    td1.appendChild(isCompleteCheckbox);

    let td2 = tr.insertCell(1);
    let textNode = document.createTextNode(item.name);
    td2.appendChild(textNode);

    let td3 = tr.insertCell(2);
    let textNode2 = document.createTextNode(item.description);
    td3.appendChild(textNode2);

    let td4 = tr.insertCell(3);
    td4.appendChild(editButton);

    let td5 = tr.insertCell(4);
    td5.appendChild(deleteButton);
  });

  agendas = data;
}

function _displayItemsSearch(data) {
    const searchTextbox = document.getElementById('search-Item');
    const tBody = document.getElementById('agendas');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const imgEdit = document.createElement('input');
    const imgTrash = document.createElement('input');

    data.forEach(item => {
        if (searchTextbox.value == item.name) {
            let isCompleteCheckbox = document.createElement('input');
            isCompleteCheckbox.type = 'checkbox';
            isCompleteCheckbox.disabled = true;
            isCompleteCheckbox.checked = item.isComplete;

            let editButton = imgEdit.cloneNode(false);
            editButton.setAttribute('src', `/IMG/edit.png`);
            editButton.setAttribute('style', `height:20px; width:20px;`);
            editButton.setAttribute('type', `image`);
            editButton.setAttribute('class', `visible`);
            editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

            let deleteButton = imgTrash.cloneNode(false);
            deleteButton.setAttribute('src', `/IMG/trash.png`);
            deleteButton.setAttribute('style', `height:20px; width:20px;`);
            deleteButton.setAttribute('type', `image`);
            deleteButton.setAttribute('class', `visible`);
            deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

            let tr = tBody.insertRow();

            let td1 = tr.insertCell(0);
            td1.appendChild(isCompleteCheckbox);

            let td2 = tr.insertCell(1);
            let textNode = document.createTextNode(item.name);
            td2.appendChild(textNode);

            let td3 = tr.insertCell(2);
            let textNode2 = document.createTextNode(item.description);
            td3.appendChild(textNode2);

            let td4 = tr.insertCell(3);
            td4.appendChild(editButton);

            let td5 = tr.insertCell(4);
            td5.appendChild(deleteButton);
        }
    });

    agendas = data;
}
