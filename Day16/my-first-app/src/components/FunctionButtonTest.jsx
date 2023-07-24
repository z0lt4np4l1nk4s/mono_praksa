import React, { useRef } from 'react'
import CustomFunctionButton from './CustomFunctionButton'

export default function FunctionButtonTest() {
    const messageInput = useRef()
    return (
        <div className='text-center bg-dark'>
            <br></br>
            <h2 className='text-light'>This is my FunctionButtonTest</h2>
            <br></br>
            <div className="mb-3 mt-3 w-25 text-center">
                <label htmlFor="message" className="form-label text-light">Message:</label>
                <input type="text" ref={messageInput} className="form-control" id="message" placeholder="Enter message" name="message" />
            </div>
            <br></br>
            <CustomFunctionButton buttonColor='light' onClick={(e) => localStorage.setItem('mySecretMessage', messageInput.current.value)} >Save to local storage!</CustomFunctionButton>
            <br></br><br></br>
            <div className="spinner-border text-light"></div>
        </div>
    );
}
