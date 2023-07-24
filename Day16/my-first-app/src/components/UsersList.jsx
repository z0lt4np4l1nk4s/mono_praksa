import React from 'react'
import UserComponent from './UserComponent'

export default function UsersList({users, onEdit, onRemove}) {
    

  return (
    <table className='table table-dark table-striped'>
        <thead>
            <tr>
                <td>Id</td>
                <td>First name</td>
                <td>Last name</td>
                <td>Email</td>
                <td>Actions</td>
            </tr>
        </thead>
        <tbody>
            {users.map((user) => 
            { 
                return ( <UserComponent 
                    key={user.id} 
                    user={user} 
                    onEdit={onEdit} 
                    onRemove={onRemove} />);
                    })}
        </tbody>
    </table>
  )
}
