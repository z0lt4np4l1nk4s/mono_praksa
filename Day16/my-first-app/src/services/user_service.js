export function getUsersList()
{
    let usersData = localStorage.getItem('users');
    const users = JSON.parse(usersData) || [];
    return users;
}

function saveUsersList(users)
{
    localStorage.setItem('users', JSON.stringify(users))
}

export function addUser(user)
{
  
    // Now you can use the "user" object as needed
    console.log(user);
  
    // For example, you can store it in local storage as shown in the previous answer
    const users = getUsersList();
    const oldUser = users.find(u => u.id === user.id);
    if(!oldUser) 
    {
        users.push(user);
        saveUsersList(users);
    }
}

export function editUser(user)
{   
    const users = getUsersList();
    const oldUser = users.find(u => u.id === user.id);
    console.log(users);
    console.log(oldUser);
    if(oldUser)
    {
        oldUser.firstName = user.firstName;
        oldUser.lastName = user.lastName;
        oldUser.email = user.email;  
        saveUsersList(users);
    }
}

export function getById(id)
{
    return getUsersList().find(u => u.id === id);
}

export function removeUser(userId) {
    const confirmation = window.confirm("Are you sure you want to delete this user?");
    
    if (confirmation) {
      const usersList = getUsersList();
      
      const index = usersList.findIndex(user => user.id === userId);
      
      if (index !== -1) {
        usersList.splice(index, 1);
        localStorage.setItem('users', JSON.stringify(usersList));
      }
    }
  }

