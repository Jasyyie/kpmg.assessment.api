import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import { MenuItem } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
  formControl: {
    margin: theme.spacing(1),
    minWidth: 500,
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
        <InputLabel id="demo-simple-select-outlined-label">{props.label}</InputLabel>
        <Select
          labelId="demo-simple-select-outlined-label"
          id="demo-simple-select-outlined"
          value={props.value}
          onChange={props.onChangeCallback}
          label={props.label}
        >
          <MenuItem value="">
            <em>None</em>
          </MenuItem>
          {props.items.map((item:any, index: number) => {
            return <MenuItem 
                    key={`${index}`} 
                    value={props.onItemRenderCallback(item)}>
                        {props.onItemRenderCallback(item)}
                    </MenuItem>
          })}
        </Select>
      </FormControl>
    </div>
  );
}