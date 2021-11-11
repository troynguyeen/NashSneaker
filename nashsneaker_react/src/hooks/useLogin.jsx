import React, { useState } from 'react';
import axios from 'axios';
import { toast } from 'react-toastify';

const useLogin = (initialFieldValues, props) => {

    const [values, setValues] = useState(initialFieldValues)
    const [errors, setErrors] = useState('');
    const [isLoading, setIsLoading] = useState(false)

    const handleInputChange = (e) => {
        const { name, value } = e.target
        const fieldValue = {[name]: value}

        setValues({
            ...values,
            ...fieldValue
        })
    }

    const handleSubmit = async (e) => {
        e.preventDefault()

        if(!values.email || !values.password) {
            setErrors('Email or password cannot be empty.')
        }
        else {
            try {
                const response = await axios.post('https://nashsneaker-api.azurewebsites.net/api/Admin/Login',
                {
                    "Email": values.email,
                    "Password": values.password,
                    "RememberMe": false
                })

                const user = response.data

                setIsLoading(true)
                localStorage.setItem("jwt", user.jwt);
                localStorage.setItem("fullName", user.fullName);

                setTimeout(() => {
                    setIsLoading(false)
                    props.setFullName(user.fullName)
                    toast('🚀 Welcome ' + user.fullName + ' !');
                }, 3000);
            }
            catch(e) {
                setIsLoading(true)
                setTimeout(() => {
                    setIsLoading(false)
                    setErrors("Incorrect Account.")
                }, 3000);
            }
        }
    }

    return {
        values,
        errors,
        isLoading,
        handleInputChange,
        handleSubmit
    }
}

export default useLogin
