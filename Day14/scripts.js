class User {
    constructor (id, firstName, lastName, email)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
    }
}

function getUsersList()
{
    let usersData = localStorage.getItem('users');
    const users = JSON.parse(usersData) || [];
    return users;
}

function createUser()
{
    const idInput = document.getElementById("id")
    const firstNameInput = document.getElementById("firstName");
    const lastNameInput = document.getElementById("lastName");
    const emailInput = document.getElementById("email");
  
    // Get the values from the form elements
    const id = idInput.value;
    const firstName = firstNameInput.value;
    const lastName = lastNameInput.value; // Parse the age as an integer
    const email = emailInput.value;
  
    // Create a new user object using the retrieved values
    const user = new User(id, firstName, lastName, email);
  
    // Now you can use the "user" object as needed
    console.log(user);
  
    // For example, you can store it in local storage as shown in the previous answer
    addOrUpdateUser(user);
    location.href = 'index.html';
}

function editUser()
{   
    const firstNameInput = document.getElementById("firstName");
    const lastNameInput = document.getElementById("lastName");
    const emailInput = document.getElementById("email");
  
    // Get the values from the form elements
    const firstName = firstNameInput.value;
    const lastName = lastNameInput.value;
    const email = emailInput.value;

    const user = getUsersList().find(u => u.id == getUserId());
    if(user !== null)
    {
        user.firstName = firstName;
        user.lastName = lastName;
        user.email = email;  
        addOrUpdateUser(user); 
    }
    location.href = 'index.html';
}

function addOrUpdateUser(user)
{
    const users = getUsersList();
    const oldUser = users.find(u => u.id === user.id);
    if(oldUser)
    {
        oldUser.firstName = user.firstName;
        oldUser.lastName = user.lastName;
        oldUser.email = user.email;
    }
    else
    {
        users.push(user);
    }

    console.log(users);

    localStorage.setItem('users', JSON.stringify(users));
}

function loadUsersToTable() {
    const tableBody = document.querySelector("#usersTable tbody");

    if(!tableBody) return;

    const users = getUsersList();
  
    // Clear any existing rows in the table
    tableBody.innerHTML = '';
  
    // Populate the table with the users' data
    users.forEach(user => {
      const row = document.createElement("tr");
      row.innerHTML = `
            <td class="td_odd">${user.id}</td>
            <td class="td_even">${user.firstName}</td>
            <td class="td_odd">${user.lastName}</td>
            <td class="td_even">${user.email}</td>
            <td class="td_odd">
                <a href="edit.html?id=${user.id}"><button class="actionButton editActionButton">Edit</button></a>
                <button class="actionButton deleteActionButton" onclick="removeUser(${user.id})">Delete</button>
            </td>
      `;
      tableBody.appendChild(row);
    });
}

function loadUserData()
{
    const userId = getUserId();
    const userForm = document.querySelector('#userForm');

    const user = getUsersList().find(u => u.id == userId);

    if(!user)
    {
        document.querySelector('#pageTitle').innerHTML = 'User with the given Id not found';
        userForm.innerHTML = '';
        return;
    }

    document.getElementById("firstName").value = user.firstName;
    document.getElementById("lastName").value = user.lastName;
    document.getElementById("email").value = user.email;
}

function getUserId()
{
    const urlParams = new URLSearchParams(window.location.search);
    const userId = urlParams.get('id');
    return userId;
}

function removeUser(userId) {
    // Ask for confirmation before deleting the user
    const confirmation = confirm("Are you sure you want to delete this user?");
    
    if (confirmation) {
      const usersList = getUsersList();
      
      // Find the index of the user with the given ID
      const index = usersList.findIndex(user => user.id === userId.toString());
      
      if (index !== -1) {
        // Remove the user from the array
        usersList.splice(index, 1);
        
        // Save the updated list back to localStorage
        localStorage.setItem('users', JSON.stringify(usersList));
        
        // Reload the table to show the updated data
        loadUsersToTable();
      }
    }
  }

document.addEventListener('DOMContentLoaded', function() {
    const tableBody = document.querySelector('#usersTable tbody');
    const userForm = document.querySelector('#userForm');

    if(tableBody) loadUsersToTable();

    if(userForm) loadUserData();
});

