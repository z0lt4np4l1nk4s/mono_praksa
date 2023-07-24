import React from 'react'
import CustomFunctionButton from './CustomFunctionButton'
import {removeUser} from '../services/index'

export default function UserComponent({user, onEdit, onRemove}) {
  return (
    <tr>
        <td>{user.id}</td>
        <td>{user.firstName}</td>
        <td>{user.lastName}</td>
        <td>{user.email}</td>
        <td>
            <CustomFunctionButton buttonColor='secondary' onClick={() => onEdit(user.id)}>Edit</CustomFunctionButton>
            <CustomFunctionButton buttonColor='danger' 
              onClick={() => 
              {
                removeUser(user.id);
                onRemove();
              }}>Delete</CustomFunctionButton>
        </td>
    </tr>
  )
}
