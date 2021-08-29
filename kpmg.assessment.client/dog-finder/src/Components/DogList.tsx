import React from 'react';
import ReactDOM from 'react-dom';
import MaterialSelect from './DropDownList';
import TitlebarImageList from './TitlebarImageList';

type MyProps = {
    // using `interface` is also ok
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
           fetch('http://localhost:5000/v1/dog')
            .then(response => response.json() as Promise<DogInfo[]>)
            .then(data => {
                this.setState({ dogList: data, loading: false});
            });
           
       }

    handleChangeCallback = (event:any) => {
        if(!!event.target.value) {
            //this.setState({ dogvalue: event.target.value }, ()=>console.log(this.state));
            fetch(`http://localhost:5000/v1/dog/${event.target.value}`)
            .then(response=>response.json()as Promise<string[]>)
            .then(data=>{
                this.setState({dogImages:data, dogvalue: event.target.value, loading:false});
            })
        } else {
            this.setState({dogImages:[], dogvalue: event.target.value, loading:false});
        }
    };
    
    handleSubbreedCallback=(doginfo:DogInfo)=>{
        if(!doginfo.subbreed)
        {
        return doginfo.breed;
        }
        return `${doginfo.breed}/${doginfo.subbreed}`
    }
     
    
   
    render() {
      return (
        <div>
            <MaterialSelect 
                label="Dog breed and subbreed" 
                value={this.state.dogvalue}
                onChangeCallback={this.handleChangeCallback}
                items={this.state.dogList}
                onItemRenderCallback={this.handleSubbreedCallback}
            >
            </MaterialSelect>
            
            <TitlebarImageList 
                items={this.state.dogImages}>
            </TitlebarImageList>
            
        </div>
      );
    }
  }
  export default DogList;
