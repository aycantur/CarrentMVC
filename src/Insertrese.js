import React, { useState, useEffect } from 'react';
import { Button, Cascader, DatePicker, Form, Select, Popover, Table, notification, Menu } from 'antd';
import axios from 'axios';
import { BrowserRouter as Router, Link } from 'react-router-dom';
import './ComponentStyle.css';


const Insertrese = () => {
    const [componentSize, setComponentSize] = useState('default');
    const [userdata, SetData] = useState(null);
    const [resdata, SetresData] = useState(null);
    const [error, SetError] = useState(null);
    const [carreslist, setcarreslist] = useState([]);
    const [buttondis, setbutton] = useState(null);
    let a = [];
    let b = [];
    let c = [];
    const getdata = async () => {
        try {
            const response = await axios.get('https://localhost:7158/api/Values/GetAllResData');
            SetData(response.data);

        } catch (error) {
            console.error(error);

        };
    }

    const getresdata = async () => {
        try {
            const response = await axios.get('https://localhost:7158/api/Values/GetCarReservationData');
            SetresData(response.data);

        } catch (error) {
            console.error(error);

        };
    }
    if (userdata == null) {
        getdata();
        getresdata();
    }


    if (userdata != null) {
        a = userdata.users.filter(x=>x.recordStatus==1);
        b = userdata.cars;
        c = userdata.carPars;
    }



    const onFormLayoutChange = ({ size }) => {
        setComponentSize(size);
    };




    const instres = async (prop) => {

        const apiUrl = 'https://localhost:7158/api/Values/InsertReservation';
        const { userId,
            carId,
            dayCount,
            price,
            reservationStartDate,
            reservationEndDatel,
            recordDate,
            recordStatus } = prop;

        console.log(prop);
        const jsonString = JSON.stringify(prop);
        fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: jsonString
        })
            .then(response => response.json())
            .then(data => {
                console.log('Response from API:', data);
            })
            .catch(error => {
                console.error('Error:', error);
            });
    };


    const [formData, setFormData] = useState({
        userId: null,
        carId: null,
        dayCount: null,
        price: null,
        reservationStartDate: null,
        reservationEndDate: null,

    });

    const handleSelectChangeUser = (selectedId) => {
        setFormData({
            ...formData,
            userId: selectedId
        });
    }

    const handleCascaderChange = (selectedIds) => {
        const selectedCarId = selectedIds[selectedIds.length - 1];
        const pricecar = userdata.cars.find(car => car.id === selectedCarId).price;
        console.log(pricecar);
        setFormData(prevData => ({
            ...prevData,
            carId: selectedCarId,
            price: pricecar
        }));
    }

    const handleStartDateChange = (date, dateString) => {
        setFormData({
            ...formData,
            reservationStartDate: dateString + 'T00:00:00'
        });
    }

    const handleEndDateChange = (date, dateString) => {

        setFormData({
            ...formData,
            reservationEndDate: dateString + 'T00:00:00',

        }
        );

    }
    const getToDay = () => {
        const today = new Date(); const yesterday = new Date(today);
        yesterday.setDate(today.getDate() - 1);
        return yesterday;
    }



    const isWithinAnyRange = (startDate, endDate, ranges) => {
        for (let range of ranges) {
            const rangeStart = new Date(range.reservationStartDate);
            const rangeEnd = new Date(range.reservationEndDate);
            if (startDate >= rangeStart && startDate <= rangeEnd) return true;
            if (endDate >= rangeStart && endDate <= rangeEnd) return true;
            if (startDate <= rangeStart && endDate >= rangeEnd) return true;
        }
        return false;
    }

    let todayy = getToDay();


    useEffect(() => {
        const startDate = new Date(formData.reservationStartDate);
        const endDate = new Date(formData.reservationEndDate);
        const differenceInMilliseconds = endDate - startDate;
        const differenceInDays = differenceInMilliseconds / (1000 * 60 * 60 * 24);

        if (differenceInDays > 0) {
            const totalprice = formData.price * differenceInDays;
            console.log(formData);

            setFormData({
                ...formData,
                dayCount: differenceInDays,
                price: totalprice
            });
        }

        const handleCarIdChange = (selectedCarId) => {
            const list = resdata.filter(x => x.carId === selectedCarId);
            setcarreslist(list);
            setFormData(prevData => ({
                ...prevData,
                carId: selectedCarId
            }));

        }
        if (startDate >= todayy && endDate > todayy && startDate < endDate) {
            const list = resdata.filter(x => x.carId === formData.carId);
            handleCarIdChange(formData.carId);
            console.log(carreslist);

            const isRangeValid = !isWithinAnyRange(startDate, endDate, list);
            setbutton(isRangeValid);
            isRangeValid == true ? SetError(null) : SetError("Seçtiğiniz araca ait ilgili tarihler doludur.");
        }
        else if (startDate > endDate && endDate > todayy) {
            SetError("Rezervasyon başlangıç bitiş tarihinden sonra olamaz.");
            setbutton(false);
        }
        else if (startDate < todayy && formData.reservationStartDate != null) {
            SetError("Rezervasyon başlangıç tarihi bugünden büyük giriniz.");
            setbutton(false);
        }
        else {
            SetError(null);
        }

    }, [formData.reservationStartDate, formData.reservationEndDate, formData.carId, Table]);


    const handleSubmit = () => {
        // formData nesnesini kullanarak göndermek istediğiniz değerlere erişebilirsiniz.
        instres(formData);
        notification.success({
            message: 'Başarılı',
            description: 'İşlem başarıyla gerçekleştirildi.',
        });

        // Form alanlarını temizle
        setFormData({
            userId: null,
            carId: null,
            dayCount: null,
            price: null,
            reservationStartDate: null,
            reservationEndDate: null,
        });

    }
    const isButtonDisabled = !formData.reservationStartDate || !formData.reservationEndDate || !buttondis;

    const dataSource = carreslist;
    console.log(dataSource);
    const columns = [
        {
            title: 'Rezervasyon Başlangıç',
            dataIndex: 'reservationStartDate',
            key: 'reservationStartDate',
            sorter: (a, b) => new Date(a.reservationStartDate) - new Date(b.reservationStartDate),

        },
        {
            title: 'Rezervasyon Bitiş',
            dataIndex: 'reservationEndDate',
            key: 'reservationEndDate',
            sorter: (a, b) => new Date(a.reservationEndDate) - new Date(b.reservationEndDate),
        }];




    return (

        <div className="component-container">
              <Link to="http://localhost:3000/home"><Button style={{backgroundColor:'',color:'GrayText',fontWeight: 'bold',fontSizeAdjust:'revert'}} block>Ana Sayfa</Button></Link>

            <h4 style={{textAlign: 'justify', marginLeft: '180px'}}>Rezervasyon oluştur</h4>
            <Form
                labelCol={{
                    span: 6,
                }}
                wrapperCol={{
                    span: 14,
                }}
                layout="horizontal"
                initialValues={{
                    size: componentSize,
                }}
                onValuesChange={onFormLayoutChange}
                size={componentSize}
                style={{
                    maxWidth: 600,
                }}
            >
                <Form.Item id='userid' label="Kullanıcı">

                    <Select onChange={handleSelectChangeUser}>
                        {a.map(item => (
                            <Select.Option key={item.id} value={item.id}>
                                {`${item.citizenShipNumber} - ${item.name} -${item.lastname}`}
                            </Select.Option>
                        ))}
                    </Select>
                </Form.Item>
                <Form.Item id='carId' label="Araç">
                    <Cascader
                        options={c.map(c => ({
                            value: c.id,
                            label: c.name,
                            children: b
                                .filter(x => x.carType === c.id || x.engineType === c.id)
                                .map(b => ({
                                    value: b.id,
                                    label: `${b.name} - ${b.engineVolume} - ${b.price} TL`,
                                })),
                        }))}
                        onChange={handleCascaderChange}
                    />
                </Form.Item>
                <Form.Item id='reservationStartDate' label="Rez Başlangıç">
                    <DatePicker onChange={handleStartDateChange} disabled={!formData.carId} />
                </Form.Item>
                <Form.Item id='reservationEndDate' label="Rez Bitiş">
                    <DatePicker onChange={handleEndDateChange} disabled={!formData.carId} />
                    <br />
                    <div style={{color:'red',fontFamily:'cursive', fontWeight: 'bold' }}>{error}</div>
                   
                </Form.Item>
                <Popover content={<Table columns={columns} dataSource={dataSource} />} title="Detay">
                    {carreslist != null && carreslist.length > 0 ? <span style={{textAlign: 'justify',color:'blue',fontFamily:'cursive', marginLeft: '150px'}}>Aracın rezervasyonları!!..</span> : null}
                </Popover>
                <Form.Item label='Kaydet'>
                    <Button onClick={handleSubmit} disabled={isButtonDisabled} >Kaydet</Button>
                </Form.Item>
            </Form>
        </div>
    );
}
export default Insertrese;