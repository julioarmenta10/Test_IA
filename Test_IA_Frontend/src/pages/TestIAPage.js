import * as React from 'react';

import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Box from '@mui/material/Box';
import { TabPanel } from '../components/TabPanel';
import { OrdenServiceCard } from '../components/OrdenServiceCard';
import { useState, useEffect } from 'react';
import { Grid } from '@mui/material';
import axios from 'axios'

function a11yProps(index) {
    return {
        id: `simple-tab-${index}`,
        'aria-controls': `simple-tabpanel-${index}`,
    };
}

export const TestIAPage = () => {
    const [value, setValue] = React.useState(0);
    const [data, setData] = useState([
        //     {
        //     order: '#0001',
        //     status: 'Pending',
        //     products: [
        //         {
        //             name: 'Pizza',
        //             quantity: '5'
        //         }, {
        //             name: 'Hamburguesa',
        //             quantity: '2'
        //         }
        //     ]
        // }, {
        //     order: '#0002',
        //     status: 'Pending',
        //     products: [
        //         {
        //             name: 'Pizza',
        //             quantity: '5'
        //         }, {
        //             name: 'Sushi',
        //             quantity: '2'
        //         }
        //     ]
        // }, {
        //     order: '#0003',
        //     status: 'Pending',
        //     products: [
        //         {
        //             name: 'Pizza',
        //             quantity: '5'
        //         }, {
        //             name: 'Gorditas',
        //             quantity: '2'
        //         }
        //     ]
        // }
    ])
    const handleChange = (event, newValue) => {
        setValue(newValue);
    };

    const getAllOrders = async () => {
        const data = axios.get('http://localhost:8080/api/Order')
            .then(function (response) {
                // handle success
                console.log(response);
                setData(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .then(function () {
                // always executed
            });
    }
    useEffect(() => {
        getAllOrders()
    }, [])

    const changeStatusOrder = async (data, newStatus) => {
        const res = await axios.put(`http://localhost:8080/api/Order/${data.id}`, {
            ...data,
            orderStatus: newStatus
        });
        getAllOrders();
    }
    return (
        <Box style={{ padding: 50 }}>
            <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
                <Tabs value={value} onChange={handleChange} aria-label="basic tabs example">
                    <Tab label="Pending" {...a11yProps(0)} />
                    <Tab label="In Process" {...a11yProps(1)} />
                    <Tab label="Completed" {...a11yProps(2)} />
                    <Tab label="Delivered" {...a11yProps(3)} />
                    <Tab label="Canceled" {...a11yProps(4)} />
                </Tabs>
            </Box>
            <TabPanel value={value} index={0}>
                <Grid container spacing={2}>
                    {data.filter(e => e.orderStatus == 'Pending').map((value, index) => (
                        <OrdenServiceCard data={value} changeStatusOrder={changeStatusOrder} />
                    ))}
                </Grid>
            </TabPanel>
            <TabPanel value={value} index={1}>
                <Grid container spacing={2}>
                    {data.filter(e => e.orderStatus == 'In Process').map((value, index) => (
                        <OrdenServiceCard data={value} changeStatusOrder={changeStatusOrder} />
                    ))}
                </Grid>
            </TabPanel>
            <TabPanel value={value} index={2}>
                <Grid container spacing={2}>
                    {data.filter(e => e.orderStatus == 'Completed').map((value, index) => (
                        <OrdenServiceCard data={value} changeStatusOrder={changeStatusOrder} />
                    ))}
                </Grid>
            </TabPanel>
            <TabPanel value={value} index={3}>
                <Grid container spacing={2}>
                    {data.filter(e => e.orderStatus == 'Delivered').map((value, index) => (
                        <OrdenServiceCard data={value} changeStatusOrder={changeStatusOrder} />
                    ))}
                </Grid>
            </TabPanel>
            <TabPanel value={value} index={4}>
                <Grid container spacing={2}>
                    {data.filter(e => e.orderStatus == 'Canceled').map((value, index) => (
                        <OrdenServiceCard data={value} changeStatusOrder={changeStatusOrder} />
                    ))}
                </Grid>
            </TabPanel>
        </Box>
    );
}
