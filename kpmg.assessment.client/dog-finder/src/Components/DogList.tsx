import React from 'react';
import ReactDOM from 'react-dom';

type MyProps = {
    // using `interface` is also ok
    message: string;
    
  };
type DogInfo={
    breed:string;
    subbreed:string;
}
  type MyState = {
    dogList:DogInfo[];
    loading:boolean;
    dogvalue:string;
    dogImages:string[];

  };

  class DogList extends React.Component<MyProps, MyState> {
       constructor(props: MyProps) {
           super(props);
           this.state={dogList:[], loading: true, dogvalue:'', dogImages:[]}
           fetch('https://localhost:5001/v1/dog')
            .then(response => response.json() as Promise<DogInfo[]>)
            .then(data => {
                this.setState({ dogList: data, loading: false}, ()=>console.log(this.state));

            });
           
       }
       handleChange = (event:any) => {
        //this.setState({ dogvalue: event.target.value }, ()=>console.log(this.state));
        fetch(`https://localhost:5001/v1/dog/${event.target.value}`)
        .then(response=>response.json()as Promise<string[]>)
        .then(data=>{
            this.setState({dogImages:data,dogvalue: event.target.value , loading:false},()=>console.log(this.state));
        })
      };
    
      handleSubbreed=(doginfo:DogInfo)=>{
        if(!doginfo.subbreed)
        {
        return doginfo.breed;
        }
        return `${doginfo.breed}/${doginfo.subbreed}`
        }
     
    
   
    render() {
      return (
        <div>
            <select onChange={this.handleChange} >
            {this.state.dogList.map(optn => (
                     <option value={this.handleSubbreed(optn)}>{optn.breed}-{optn.subbreed}</option>
                 ))}
            </select>
            {this.state.dogImages.map((image, index) => {
            return <img src={image} id={`${index}`}/>
            })
        }
        </div>
      );
    }
  }
  export default DogList;
