import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useHistory } from 'react-router';
import { toast } from 'react-toastify';

const useLogin = (initialFieldValues, props) => {

    const [values, setValues] = useState(initialFieldValues)
    const [errors, setErrors] = useState('');
    const [isLoading, setIsLoading] = useState(false)

    const location = useHistory();

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
                const response = await axios.post('https://localhost:44357/api/Admin/Login',
                {
                    "Email": values.email,
                    "Password": values.password,
                    "RememberMe": false
                 })

                const user = response.data

                console.log(response)

                setIsLoading(true)
                sessionStorage.setItem("jwt", user.jwt);
                sessionStorage.setItem("fullName", user.fullName);

                setTimeout(() => {
                    setIsLoading(false)
                    props.setFullName(user.fullName)
                    toast('🚀 Welcome ' + user.fullName + ' !')
                    location.goBack()

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
