
import React, { useState } from 'react'
import { Table,Button   } from 'antd';
import axios from 'axios';
import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom';

import { Tabs } from 'antd';

const { Column } = Table;


const CarrentPage = () => {

  const [cardata, SetData] = useState(null);
  const [cardatauni, setNewData] = useState(null);
  const updatedCardatas = [];
  let searchInput = null;
  const handleSearch = (selectedKeys, confirm, dataIndex) => {
    confirm();
    // Filtreleme işlemleri burada gerçekleştirilebilir
  };
  const handleReset = clearFilters => {
    clearFilters();
    // Filtre sıfırlama işlemleri burada gerçekleştirilebilir
  };
  const getdata = async () => {
    try {
      const response = await axios.get('https://localhost:7158/api/Values/GetAllReservationData');
      SetData(response.data);
      write(response.data);

    } catch (error) {
      console.error(error);

    };
  }
if (cardata ===null) {
  getdata();
}

  const write = (a) => {
    //console.log('abc');
    if (a !== null) {
      for (let index = 0; index < a.length; index++) {
        const element = a[index];
        const { id, userId, carId, dayCount, reservationStartDate, price, reservationEndDate, recordDate, recordStatus, cars: [{ engineVolume, name: carName, price: dailyPrice }], users: [{ citizenShipNumber }], users: [{ lastname, name: userName }], carPars: [{ name: cartypename }, { name: carenginetypename }] } = element;
        const updatedCardata = { id, userId, carId, dayCount, reservationStartDate, reservationEndDate, recordDate, recordStatus, engineVolume, carName, price, userName, citizenShipNumber, lastname, cartypename, carenginetypename, dailyPrice };

        updatedCardatas.push(updatedCardata);
      }
      //console.log(updatedCardatas);
      setNewData(updatedCardatas);
    }


  }



  const { TabPane } = Tabs;
  const handleFilterChange = (pagination, filters, sorter) => {
    console.log('Various parameters', pagination, filters, sorter);
    // Burada filtreleme ve sıralama parametrelerini kullanarak verilerinizi güncelleyebilirsiniz.
  }

  const dataSource = cardatauni;
  const carcolumns = [
    {
      title: 'TCKN',
      dataIndex: 'citizenShipNumber',
      key: 'citizenShipNumber',
      sorter: (a, b) => a.citizenShipNumber.localeCompare(b.citizenShipNumber),


    },
    {
      title: 'Ad',
      dataIndex: 'userName',
      key: 'userName',
      sorter: (a, b) => a.userName.localeCompare(b.userName),

    },
    {
      title: 'Soyad',
      dataIndex: 'lastname',
      key: 'lastname',
      sorter: (a, b) => a.lastname.localeCompare(b.lastname),
    },
    {
      title: 'Araç Adı',
      dataIndex: 'carName',
      key: 'carName',
      sorter: (a, b) => a.carName.localeCompare(b.carName),
    },
    {
      title: 'Motor Hacmi',
      dataIndex: 'engineVolume',
      key: 'engineVolume',
      sorter: (a, b) => a.engineVolume.localeCompare(b.engineVolume),
    },
    {
      title: 'Motor Türü',
      dataIndex: 'carenginetypename',
      key: 'carenginetypename',
      sorter: (a, b) => a.carenginetypename.localeCompare(b.carenginetypename),
    },
    {
      title: 'Araç Türü',
      dataIndex: 'cartypename',
      key: 'cartypename',
      sorter: (a, b) => a.cartypename.localeCompare(b.cartypename),
    },
    {
      title: 'Günlük Ücret',
      dataIndex: 'dailyPrice',
      key: 'dailyPrice',
      sorter: (a, b) => a.dailyPrice - b.dailyPrice,
    },
    {
      title: 'Kiralanan Gün',
      dataIndex: 'dayCount',
      key: 'dayCount',
      sorter: (a, b) => a.dayCount - b.dayCount,
    },
    {
      title: 'Toplam Ücret',
      dataIndex: 'price',
      key: 'price',
      sorter: (a, b) => a.price - b.price,
    },
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
      sorter: (a, b) => new Date(a.reservationEndDate) - new Date(b.reservationEndDate), // Tarihleri karşılaştır

    },

  ];
  return (
    <div>
  <Link to="http://localhost:3000/home"><Button style={{backgroundColor:'chocolate',color:'GrayText',fontWeight: 'bold',fontSizeAdjust:'revert'}} block>Ana Sayfa</Button></Link>

      <h2 style={{backgroundColor:'orange',textAlign: 'center', color: 'grey',fontStyle: 'italic'}}>Rezervasyon Listesi</h2>
      
      {cardata ? <Table dataSource={dataSource}
        columns={carcolumns}
        pagination={{ pageSize: 5 }}
        onChange={handleFilterChange} style={{ background: 'grey', color: 'black' }} /> : <div>Loading....</div>}
      <img src="/image/aa.jpg" alt="Açıklama" />

    </div>
  );
}


export default CarrentPage