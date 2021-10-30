import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useHistory } from 'react-router';

const useApi = (initialValue) => {

    const location = useHistory();

    const [list, setList] = useState([]);
    const [values, setValues] = useState(initialValue);
    const [message, setMessage] = useState('')

    const handleInputChange = (e) => {
        const { name, value } = e.target
        const fieldValue = {[name]: value}

        setValues({
            ...values,
            ...fieldValue
        })
    }

    //GET API
    const fetchAPI = async (ApiName) => {
        try {
            const response = await axios.get(`https://localhost:44357/api/Admin/${ApiName}`, 
            {
                headers: {
                  'Authorization': `Bearer ${sessionStorage.getItem("jwt")}`
                }
            })

            setList(response.data)
        }
        catch(e) {
            console.log(e)
        }
    }

    //POST API
    const PostAPI = async (ApiName) => {
        try {
            const response = await axios.post(`https://localhost:44357/api/Admin/${ApiName}`, values,
            {
                headers: {
                  'Authorization': `Bearer ${sessionStorage.getItem("jwt")}`
                }
            })

            setMessage(response.data.message)
            location.goBack()
        }
        catch(e) {
            console.log(e)
            setMessage('error')
        }
    }

    //PUT API
    const PutAPI = async (ApiName) => {
        try {
            const response = await axios.get(`https://localhost:44357/api/Admin/${ApiName}`, values,
            {
                headers: {
                  'Authorization': `Bearer ${sessionStorage.getItem("jwt")}`
                }
            })

            setMessage(response.data.message)
        }
        catch(e) {
            console.log(e)
            setMessage('error')
        }
    }

    //DELETE API
    const DeleteAPI = async (ApiName, id) => {
        try {
            const response = await axios.get(`https://localhost:44357/api/Admin/${ApiName}/${id}`,
            {
                headers: {
                  'Authorization': `Bearer ${sessionStorage.getItem("jwt")}`
                }
            })

            setMessage(response.data.message)
        }
        catch(e) {
            console.log(e)
            setMessage('error')
        }
    }

    return {
        list,
        values,
        setValues,
        message,
        setMessage,
        fetchAPI,
        PostAPI,
        PutAPI,
        DeleteAPI,
        handleInputChange
    }
}

export default useApi
