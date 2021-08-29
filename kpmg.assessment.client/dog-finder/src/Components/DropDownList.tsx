import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import { MenuItem } from '@material-ui/core';
import { OptionInfo } from './DogList';

const useStyles = makeStyles((theme) => ({
  formControl: {
    margin: theme.spacing(1),
    minWidth: 300,
  },
  selectEmpty: {
    marginTop: theme.spacing(2),
  },
}));
  
export default function MaterialSelect(props:any) {
    
  const classes = useStyles();
  
  return (
    <div>
      <FormControl variant="outlined" className={classes.formControl}>
        <InputLabel id={`${props.id}-select-outlined-label`}>{props.label}</InputLabel>
        <Select
          labelId={`${props.id}-select-outlined-label`}
          id={`${props.id}-select-outlined`}
          value={props.value}
          onChange={props.onChangeCallback}
          label={props.label}
        >
          <MenuItem value="">
            <em>None</em>
          </MenuItem>
          {props.items.map((item:OptionInfo, index: number) => {
            return <MenuItem 
                    key={`${index}`} 
                    value={item.value}>
                        {item.name}
                    </MenuItem>
          })}
        </Select>
      </FormControl>
    </div>
  );
}