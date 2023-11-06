
import './Tabbutton.css'

const SearchTab=()=>{
    return(
        <div className="tab" >
            <Search/>
            <DetailSearch/>
        </div>
    )
}
const openSearch=(search)=>{
    if (search=='ara') {
        <Search/>
   }
   else{
<DetailSearch/>
   }

}

const Search=()=>{
    return(
        
        <div>
            <input type="text" id="search"></input>

        </div>
            
            )
}
const DetailSearch=()=>{
    return (
        <div>
            <h5>Detay Ara</h5>
            <label>Model</label>
            <input type="text" id="ModelSearch"></input>
            <br/>
            <label>Yıl</label>
            <input type="text" id="YılSearch"></input>
            <br/>
            <label>KM</label>
            <input type="text" id="KmSearch"></input>
        </div>
    )
    
}

export default SearchTab