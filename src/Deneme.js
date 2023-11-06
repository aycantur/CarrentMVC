
import React, { useState } from 'react';
import {
  Button,
  Cascader,
  DatePicker,
  Form,
  Input,
  InputNumber,
  Radio,
  Select,
  Switch,
  TreeSelect,
} from 'antd';
import axios from 'axios';

  const Apppp = () => {
    const [formData, setFormData] = useState({
        carId: null, // Bu değeri uygun şekilde ayarlayın
    });

    const [reservedDates, setReservedDates] = useState(['2023-10-25', '2023-10-26']); // Rezerve edilmiş tarihler

    const handleStartDateChange = (date) => {
        // Başlangıç tarihi değiştiğinde yapılacak işlemler
    }

    const handleEndDateChange = (date) => {
        // Bitiş tarihi değiştiğinde yapılacak işlemler
    }

    const isDateReserved = (date) => {
        return reservedDates.includes(date.format('YYYY-MM-DD'));
    }

    return (
        <>
            <Form.Item id='reservationStartDate' label="Rez Başlangıç">
                <DatePicker
                    onChange={handleStartDateChange}
                    
                    disabledDate={current => isDateReserved(current.format('YYYY-MM-DD'))}
                />
            </Form.Item>
            <Form.Item id='reservationEndDate' label="Rez Bitiş">
                <DatePicker
                    onChange={handleEndDateChange}
                    
                    disabledDate={current => isDateReserved(current.format('YYYY-MM-DD'))}
                />
            </Form.Item>
            
            
        </>
    );
}
  
  export default Apppp;
  