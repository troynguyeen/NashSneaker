import React from 'react'

const Dashboard = (props) => {
    return (
        <React.Fragment>
            <div style={{ paddingLeft: '150px' }}>
                <div style={{  
                    fontSize: '30px', 
                    fontWeight: 'bold',
                    textAlign: 'center',
                    marginTop: '50px'
                }}>
                    Welcome Admin {props.fullName} !
                </div>
                <div style={{ 
                    background: 'linear-gradient(65deg,  #FC466B, #3F5EFB)',
                    borderRadius: '100px',
                    color: '#fff', 
                    fontSize: '70px', 
                    fontWeight: 'bold',
                    textAlign: 'center',
                    padding: '50px',
                    marginTop: '50px',
                    marginLeft: '150px',
                    width: '600px',
                    height: '600px'
                }}>
                    <div 
                    style={{ 
                        background: 'linear-gradient(90deg,  #FC466B, #3F5EFB)',
                        borderRadius: '100px',
                        color: '#fff', 
                        fontSize: '70px', 
                        fontWeight: 'bold',
                        textAlign: 'center',
                        padding: '350px',
                        paddingBottom: '170px'
                    }}>
                        Dashboard Site
                    </div>
                </div>
            </div>
        </React.Fragment>
    )
}

export default Dashboard
