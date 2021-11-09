import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useHistory } from 'react-router';

const useApi = (initialValue) => {

    const history = useHistory();

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
    const FetchAPI = async (ApiName) => {
        try {
            const response = await axios.get(`https://localhost:44348/api/Admin/${ApiName}`, 
            {
                headers: {
                  'Authorization': `Bearer ${localStorage.getItem("jwt")}`
                }
            })

            setList(response.data)
        }
        catch(e) {
            console.log(e)
        }
    }

    //GET API by Id
    const GetByIdAPI = async (ApiName, id) => {
        try {
            const response = await axios.get(`https://localhost:44348/api/Admin/${ApiName}/${id}`, 
            {
                headers: {
                  'Authorization': `Bearer ${localStorage.getItem("jwt")}`
                }
            })

            setValues({...response.data})
        }
        catch(e) {
            console.log(e)
        }
    }

    //POST API
    const PostAPI = async (ApiName, formData = null) => {
        try {
            const response = await axios.post(`https://localhost:44348/api/Admin/${ApiName}`, formData != null ? formData : values,
            {
                headers: {
                  'Authorization': `Bearer ${localStorage.getItem("jwt")}`
                }
            })

            setMessage(response.data.message)
            history.goBack()
        }
        catch(e) {
            console.log(e)
            setMessage('error')
        }
    }

    //PUT API
    const PutAPI = async (ApiName, formData = null) => {
        try {
            const response = await axios.put(`https://localhost:44348/api/Admin/${ApiName}`, formData != null ? formData : values,
            {
                headers: {
                  'Authorization': `Bearer ${localStorage.getItem("jwt")}`
                }
            })

            setMessage(response.data.message)
            history.goBack()
        }
        catch(e) {
            console.log(e)
            setMessage('error')
        }
    }

    //DELETE API
    const DeleteAPI = async (ApiName, id) => {
        try {
            const response = await axios.delete(`https://localhost:44348/api/Admin/${ApiName}/${id}`,
            {
                headers: {
                  'Authorization': `Bearer ${localStorage.getItem("jwt")}`
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
        setList,
        values,
        setValues,
        message,
        setMessage,
        FetchAPI,
        GetByIdAPI,
        PostAPI,
        PutAPI,
        DeleteAPI,
        handleInputChange
    }
}

export default useApi
