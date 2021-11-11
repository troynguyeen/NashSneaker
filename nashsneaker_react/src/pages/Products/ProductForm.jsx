import React, { useState, useEffect } from 'react'
import TextareaAutosize from '@mui/material/TextareaAutosize';
import { Button, ButtonGroup, CircularProgress, Container, Grid, Modal, Paper, TextField } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import useApi from '../../hooks/useApi';
import { toast, ToastContainer } from 'react-toastify';
import { AiOutlineArrowLeft } from "react-icons/ai";
import { useHistory, useParams, useLocation } from 'react-router-dom';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import ImageUploading from "react-images-uploading";
import { BsCloudUploadFill } from "react-icons/bs";
import DeleteIcon from '@material-ui/icons/Delete';
import { Box } from '@mui/system';

const useStyles = makeStyles((theme) => ({
    root: {
        '& .MuiTextField-root': {
            margin: theme.spacing(2),
            minWidth: '600px'
        },
        '& .MuiGrid-root': {
            textAlign: 'center'
        },
        '& .MuiInput-root': {
            width: '180px'
        }
    },
    container: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center'
    },
    paper: {
        padding: '20px',
        margin: '30px',
        width: '700px'
    },
    grid: {
        flexDirection: 'row',
        alignItems: 'center'
    },
    buttonContainer: {
        display: 'flex',
        justifyContent: 'space-around',
        margin: '25px 15px'
    },
    button: {
        marginRight: '15px !important'
    },
    boxLoading: {
        position: 'absolute',
        top: '35%',
        left: '48%',
        outline: 'none'
    },
}))

const initialValue = {
    name: '',
    categoryId: '',
    price: '',
    description: ''
}

const ProductForm = () => {

    const classes = useStyles();

    const history = useHistory();
    const location = useLocation();
    const param = useParams();

    const [imagesDelete, setImagesDelete] = useState([])
    const [images, setImages] = useState([])
    const [title, setTitle] = useState('Add new product')
    
    const {list, values, setValues, message, setMessage, FetchAPI, GetByIdAPI, PostAPI, PutAPI, handleInputChange} = useApi(initialValue);

    const serverUrl = 'https://localhost:44357/images/products/';

    useEffect(() => {
        if(message !== '') {
            if(message === 'error') {
                toast.error("Something went wrong!", {
                    theme: "colored"
                });
            }
            else {
                toast.success(message, {
                    theme: "colored"
                });
            }
        }

    }, [message])

    useEffect(() => {
        //Switch route
        if(location.pathname.includes("edit")) {
            param.id > 0 ? GetByIdAPI('GetProductById', param.id) : history.push('/products')
            setTitle('Edit Product');
        }

        //fetchAPI for categories select
        FetchAPI("Categories");

    }, [])

    useEffect(() => {
        //for update product
        if(values.category != null && values.categoryId == null) {
            setValues({...values, categoryId: values.category.id})
        }

        if(values.images != null && images.length == 0) {
            const imagePath = []
            values.images.map(img => imagePath.push({data_url: img.path, path: img.path}))
            setImages(imagePath)
        }
    }, [values])

    const handleSubmit = async (e) => {
        e.preventDefault();

        if(values.name != '' && values.categoryId != '' && values.price != '' && values.description != '' && images.length > 0) {
            const formData = new FormData();
            formData.append('id', values.id ? values.id : 0);
            formData.append('name', values.name);
            formData.append('categoryId', values.categoryId);
            formData.append('price', values.price);
            formData.append('description', values.description);
            images.map(img => {
                if(img.file != null) {
                    formData.append('imagesName', img.file.name);
                    formData.append('imagesFile', img.file);
                }
            })
            imagesDelete.map(img => formData.append('imagesDelete', img.replace('https://nashsneaker.blob.core.windows.net/images/', '')));

            //this the data for sizes because I have no time to make the UI
            const sizes = [39, 40, 41];
            sizes.map(size => formData.append('sizes', size));

            param.id > 0 ? PutAPI('EditProduct', formData) : PostAPI('AddNewProduct', formData);
            setMessage('');

        }
        else {
            toast.warning("All information can not be empty", {
                theme: "colored"
            });
        }
    }

    const handleReset = () => {
        setValues(initialValue);
    }

    const onChangeImages = (imageList) => {
        //images for preview
        setImages(imageList);

        //Get images to delete
        if(values.images != null && values.images.length > 0) {
            const initialImages = values.images.map(x => x.path);
            const updatedImages = imageList.map(x => x.path);

            const deletedImages =  initialImages.filter(img => !updatedImages.includes(img))
            setImagesDelete(deletedImages)
        }
    };
    
    return (
        <Container className={classes.container}>
            <h2>{title}</h2>
            <Paper className={classes.paper} elevation={5}>
                <AiOutlineArrowLeft onClick={() => history.push('/products')} style={{ fontSize: '25px', cursor: 'pointer' }}/>
                <form noValidate className={classes.root} onSubmit={handleSubmit}>
                    <Grid container>
                        <Grid item xs={12}>
                            <TextField
                                name="name"
                                variant="outlined"
                                label="Name"
                                value={values.name}
                                onChange={handleInputChange}
                            />
                        </Grid>
                        <Grid item xs={6}>
                            <FormControl style={{ width: '275px', margin: '16px', marginLeft: '40px' }}>
                                <InputLabel id="label">Category</InputLabel>
                                <Select
                                    name="categoryId"
                                    labelId="label"
                                    variant="outlined"
                                    value={values.category != null && values.categoryId == null ? values.category.id : values.categoryId}
                                    label="Category"
                                    onChange={handleInputChange}
                                    style={{ textAlign: 'start' }}
                                >
                                    {list.map(category => <MenuItem value={category.id}>{category.name}</MenuItem>)}
                                </Select>
                            </FormControl>
                        </Grid>
                        <Grid item xs={6}>
                            <TextField
                                name="price"
                                variant="outlined"
                                type="number"
                                label="Price"
                                value={values.price}
                                onChange={handleInputChange}
                                style={{ minWidth: '300px', marginLeft: '-30px' }}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextareaAutosize
                                name="description"
                                value={values.description}
                                onChange={handleInputChange}
                                aria-label="textarea"
                                placeholder="Description..."
                                style={{ width: '570px', height: '150px', margin: '20px', padding: '15px', fontSize: '1rem', fontFamily: 'inherit' }}
                            />
                        </Grid>
                        <Grid item xs={12} style={{ display: 'flex', justifyContent: 'center', margin: '30px 0' }}>
                            <ImageUploading
                                multiple
                                value={images}
                                onChange={onChangeImages}
                                maxNumber={3}
                                dataURLKey="data_url"
                            >
                                {({
                                    imageList,
                                    onImageUpload,
                                    onImageRemoveAll,
                                    onImageUpdate,
                                    onImageRemove,
                                    isDragging,
                                    dragProps,
                                    errors
                                }) => (
                                // write your building UI
                                <div className="upload__image-wrapper" style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
                                    <div 
                                        onClick={onImageUpload} 
                                        {...dragProps} 
                                        style={{ 
                                            display: 'flex', 
                                            alignItems: 'center',
                                            justifyContent: 'center',
                                            border: '1px solid #C8C8C8',
                                            borderRadius: '4px',
                                            padding: '8px',
                                            marginBottom: '50px',
                                            width: '150px'
                                        }}
                                    >
                                        <BsCloudUploadFill
                                            style={{ 
                                                color: '#1D976C',
                                                fontSize: '23px',
                                                paddingRight: '10px'
                                            }}
                                        />
                                        <div style={{ fontWeight: 'bold' }}>Upload images</div>
                                    </div>
                                    {
                                        errors && <div style={{ color: 'red', fontSize: '15px', paddingBottom: '20px'}}>
                                            {errors.maxNumber && <span>You can only upload maximum 3 images</span>}
                                            {errors.acceptType && <span>Your selected file type is not allow</span>}
                                            {errors.maxFileSize && <span>Selected file size exceed maxFileSize</span>}
                                            {errors.resolution && <span>Selected file is not match your desired resolution</span>}
                                        </div>
                                    }
                                    <div style={{ display: 'flex' }}>
                                        {
                                            imageList.map((image, index) => (
                                                <div key={index} className="image-item" style={{ padding: '0 15px' }}>
                                                    <img src={image.data_url} alt="" width="200" onClick={() => onImageUpdate(index)} />
                                                    <div>
                                                        <DeleteIcon color="secondary" onClick={() => onImageRemove(index)} style={{ paddingTop: '5px' }}/>
                                                    </div>
                                                </div>
                                            ))
                                        }
                                    </div>
                                </div>
                                )}
                            </ImageUploading>
                        </Grid>
                        <Grid item xs={12}>
                            <div className={classes.buttonContainer}>
                                <Button className={classes.button} variant="contained" color="primary" type="submit">Submit</Button>
                                <Button style={{ backgroundColor: '#DCDCDC', color: '#000' }} variant="contained" type="reset" onClick={handleReset}>Reset</Button>
                            </div>
                        </Grid>
                    </Grid>
                </form>
            </Paper>
        </Container>
    )
}

export default ProductForm
