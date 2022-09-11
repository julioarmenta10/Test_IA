import * as React from 'react';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import { CardHeader, Grid, List, ListItem, ListItemText } from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import SendIcon from '@mui/icons-material/Send';
import CheckIcon from '@mui/icons-material/Check';
import LocalShippingIcon from '@mui/icons-material/LocalShipping';
import Divider from '@mui/material/Divider';

import {
    makeStyles
} from '@mui/styles'
const useStyles = makeStyles((theme) => ({

    card: {
        borderRadius: 15,
        maxWidth: '100%',
        // minWidth: '270px',
        height: '100%',
        backgroundColor: 'rgba(234,241,247,0.3)',
        boxShadow:
            'rgba(50, 50, 93, 0.25) 0px 10px 20px -20px, rgba(0, 0, 0, 0.3) 0px 10px 10px -30px, rgba(10, 37, 64, 0.35) 0px -2px 6px 0px inset;',
        // boxShadow:
        //   'rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;',
    }

}))

export const OrdenServiceCard = (props) => {
    const { data, changeStatusOrder } = props
    const classes = useStyles()

    const nextStatus = (status) => {
        switch (status) {
            case 'Pending':
                return 'In Process'
            case 'In Process':
                return 'Completed'
            case 'Completed':
                return 'Delivered'

        }
    }

    const nextStatusIcon = (status) => {
        switch (status) {
            case 'Pending':
                return <SendIcon />
            case 'In Process':
                return <CheckIcon />
            case 'Completed':
                return <LocalShippingIcon />

        }
    }

    return (
        <Grid item xs={12} md={6} lg={4} >

            <Card sx={{ minWidth: 275 }} className={classes.card}>
                <Grid container xs={12} style={{ paddingLeft: 10, paddingRight: 10 }}>
                    <Grid xs={6}>
                        <h3>Order Number #{data.orderNumber}</h3>
                    </Grid>
                    <Grid xs={6} style={{ textAlign: 'right', alignSelf: 'center' }}>
                        <Button variant="contained" disabled>
                            {data.orderStatus}
                        </Button>
                    </Grid>

                </Grid>
                <Divider variant="middle" />

                <CardContent style={{ paddingTop: 0 }}>
                    <Grid container xs={12} style={{ paddingLeft: 10, paddingRight: 10 }}>
                        <Grid xs={6}>
                            <Typography sx={{ mt: 4, mb: 2 }} style={{ fontWeight: 'bold' }} variant="h6" component="div">
                                Order Detail
                            </Typography>
                            <List >
                                {data.orderDetails.map((value, index) => (
                                    <>
                                        <ListItem>
                                            <ListItemText
                                                primary={value.product.description + ' - ' + value.quantity}
                                            />
                                        </ListItem>

                                    </>
                                ))}
                            </List>
                        </Grid>

                    </Grid>


                    {data.orderStatus !== "Canceled" && data.orderStatus !== "Delivered" ? (
                        <Grid container rowSpacing={1} columnSpacing={2} style={{
                            textAlign: 'center'
                        }}>
                            <Grid item xs={12} md={6}>
                                <Button variant="contained" style={{ minWidth: 150 }} color="success" startIcon={nextStatusIcon(data.orderStatus)} onClick={() => changeStatusOrder(data, nextStatus(data.orderStatus))}>
                                    {nextStatus(data.orderStatus)}
                                </Button>
                            </Grid>
                            <Grid item xs={12} md={6}>
                                <Button variant="contained" style={{ minWidth: 150 }} startIcon={<DeleteIcon />} color="error" onClick={() => changeStatusOrder(data, "Canceled")}>
                                    Cancel
                                </Button>
                            </Grid>
                        </Grid>
                    ) : null}
                </CardContent>

            </Card>
        </Grid>
    );
}
