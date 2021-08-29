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

export type OptionInfo={
    value:string;
    name: string;
}

type MyState = {
    dogList:DogInfo[];
    dogListGroupBy: {[breed: string]: string[]}
    breedList: OptionInfo[];
    subbreedList: OptionInfo[];
    loading:boolean;
    selectedBreed:string;
    selectedSubbreed:string;
    dogImages:string[];
};

  class DogList extends React.Component<MyProps, MyState> {
    constructor(props: MyProps) {
        super(props);

        this.state={
            dogList:[],
            dogListGroupBy: {},
            loading: true, 
            selectedBreed: '', 
            selectedSubbreed: '', 
            dogImages:[],
            breedList: [],
            subbreedList: [],
        }
        fetch('http://localhost:5000/v1/dog')
        .then(response => response.json() as Promise<DogInfo[]>)
        .then(data => {
            // logic to split breed and related subbreeds
            const groups = this.groupByDogBreed(data);
            const breeds: OptionInfo[] = Object.keys(groups).map(x => {
                return {
                    value: x,
                    name: x,
                };
            });

            this.setState({ dogList: data, dogListGroupBy: groups, breedList: breeds, loading: false});
        });
    }

    handleBreedChangeCallback = (event:any) => {
        if(!!event.target.value) {
            fetch(`http://localhost:5000/v1/dog/${event.target.value}`)
            .then(response=>response.json()as Promise<string[]>)
            .then(data=>{
                const subbreeds:OptionInfo[] = this.state.dogListGroupBy[event.target.value].map(x => {
                    return {
                        value: x,
                        name: x,
                    };
                });
                this.setState({
                    dogImages:data, 
                    selectedBreed: event.target.value, 
                    subbreedList: subbreeds,
                    selectedSubbreed:'', 
                    loading:false
                });
            })
        } else {
            this.setState({
                dogImages:[], 
                selectedBreed: event.target.value, 
                subbreedList: [],
                selectedSubbreed:'', 
                loading:false
            });
        }
    };

    handleSubbreedChangeCallback = (event:any) => {
        let endpoint = this.state.selectedBreed;

        if(!!event.target.value) {
            endpoint = endpoint + `/${event.target.value}`;
        }

        fetch(`http://localhost:5000/v1/dog/${endpoint}`)
            .then(response=>response.json()as Promise<string[]>)
            .then(data=>{
                this.setState({
                    dogImages:data, 
                    selectedSubbreed: event.target.value, 
                    loading:false
                });
            });
    };

    // https://codereview.stackexchange.com/questions/37028/grouping-elements-in-array-by-multiple-properties
    groupByDogBreed = (arr: DogInfo[]): {[breed: string]: string[]} => {

    let groups: {[breed: string]: string[]} = {};

    arr.forEach((item) => {
      let group: string = item.breed;
      groups[group] = groups[group] || [];
      groups[group].push(item.subbreed);
    });

    return groups;

  };
     
    render() {
      return (
        <div>
            <MaterialSelect
                id="dog-breed"
                label="Breed" 
                value={this.state.selectedBreed}
                onChangeCallback={this.handleBreedChangeCallback}
                items={this.state.breedList}
            >
            </MaterialSelect>
            <MaterialSelect 
                id="dog-sub-breed"
                label="Sub-breed" 
                value={this.state.selectedSubbreed}
                onChangeCallback={this.handleSubbreedChangeCallback}
                items={this.state.subbreedList}
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
