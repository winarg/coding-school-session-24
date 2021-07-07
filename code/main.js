var itemsList = [];
var incId = 0;

function addNew() {
    document.getElementById('frmMain').reset();
    document.getElementById('txtSelectedId').value = null;
}

function addToList() {
    var name = document.getElementById("txtName").value;
    var description = document.getElementById("txtDescription").value;

    var selectedId = +document.getElementById("txtSelectedId").value;
    if (selectedId) {
        for(var i=0; i<itemsList.length; i++){
            var curItem = itemsList[i];
            if(curItem.id !== selectedId )
                continue;

            curItem.name = name;
            curItem.description = description;
            break;
        }
    } else {
        incId += 1;
        itemsList.push({ id: incId, name, description });
    }
    redrawList();
}

function redrawList() {

    var lstList = document.getElementById("lstList");

    lstList.innerHTML = "";
    for (var i = 0; i < itemsList.length; i++) {

        var curListItem = itemsList[i];
        var tmpLi = document.createElement("li");
        tmpLi.appendChild(document.createTextNode(curListItem.name));
        tmpLi.setAttribute('data-id', curListItem.id);
        tmpLi.addEventListener('click', (event) => {
            loadSelectedItem(event);
        });

        lstList.appendChild(tmpLi);
    }
}

function loadSelectedItem(e) {
    var selectedId = +e.target.dataset.id;

    var selectedItem = findItemById(selectedId);

    removePreviousSelection();
    e.target.classList.add('selected');

    document.getElementById("txtName").value = selectedItem.name;
    document.getElementById("txtDescription").value = selectedItem.description;
    document.getElementById("txtSelectedId").value = selectedItem.id;
}

function removePreviousSelection(){
    var selection = document.getElementsByClassName("selected");
    for(var element of selection)
    {
        element.classList.remove('selected');
    }
}

function removeFromList(){
    var selectedId = +document.getElementById("txtSelectedId").value;
    var foundIndex = itemsList.findIndex( c=> c.id === selectedId);
    
    if(foundIndex === -1)
        return;
    
    itemsList.splice(foundIndex, 1);
    redrawList();
}

function findItemById(id) {
    return itemsList.find(c => c.id === id);
}