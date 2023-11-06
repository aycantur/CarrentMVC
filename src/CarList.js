import { useState } from "react";


const CarList = (prop) => {

    const { propsl } = prop;
    const row = [];

    propsl.forEach(t => {
        row.push(<Carrow cars={t} />)
    });
    return (
        <table style={{ border: "1px solid black", borderCollapse: "collapse", width: '50%' }}>
            <thead style={{ border: "1px solid black", borderCollapse: "collapse" }}>
                <tr style={{ border: "1px solid black", borderCollapse: "collapse" }}>
                    <th style={{ border: "1px solid black", borderCollapse: "collapse", textAlign: 'center' }}>Model</th>
                    <th style={{ border: "1px solid black", borderCollapse: "collapse", textAlign: 'center' }}>Yil</th>
                    <th style={{ border: "1px solid black", borderCollapse: "collapse", textAlign: 'center' }}>KM</th>
                    <th style={{ border: "1px solid black", borderCollapse: "collapse", textAlign: 'center' }}>Fiyat</th>
                    <th style={{ border: "1px solid black", borderCollapse: "collapse", textAlign: 'center', width: 100 }}>Gün</th>
                    <th style={{ border: "1px solid black", borderCollapse: "collapse", textAlign: 'center' }}>Tutar</th>
                </tr>
            </thead>
            <tbody style={{ border: "1px solid black", borderCollapse: "collapse" }}>

                {row}
            </tbody>
        </table>
    )
}

export default CarList



const Carrow = (prop) => {
    const { cars } = prop;
    const [a, b] = useState(0);
    const [c,d]=useState(0);
    const Increase = (aaa) => {
        b(a+1);
        Total(aaa);
    };
    const Decrease = () => {
        if (a>0) {
            b(a-1);    
        }
    };
const Total=(total)=>{
let ab=total;
d(ab+c);
console.log(c);
}

    return (
        <tr style={{ border: "1px solid black", borderCollapse: "collapse" }}>
            <td style={{ border: "1px solid black", borderCollapse: "collapse" }}>{cars.Model}</td>
            <td style={{ border: "1px solid black", borderCollapse: "collapse", textAlign: 'right' }}>{cars.Yil}</td>
            <td style={{ border: "1px solid black", borderCollapse: "collapse", textAlign: 'right' }}>{cars.Km}</td>
            <td style={{ border: "1px solid black", borderCollapse: "collapse", textAlign: 'right' }}>{cars.Fiyat}</td>
            <td style={{ maxWidth: 100, border: "1px solid black", borderCollapse: "collapse", textAlign: 'right' }}>
                <button  onClick= {Decrease}>-</button>
                <input type="text"  defaultValue={0} style={ {width: 20, textAlign: 'right'}} value={a} min={0}/>
                <button onClick= {()=>{Increase(cars.Fiyat)}}>+</button></td>
                <td id="Prices">{a*cars.Fiyat}</td>
        </tr>
     
    )
    

};
