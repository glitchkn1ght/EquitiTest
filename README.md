# EquitiTest

#Design Considerations
- I didn't add try/catch blocks into the CustomerRetrieval class itself as different clients might want to implement different kinds of error catching. 
- I considered adding a logger to capture when orders had null orderdates or null customers but thought it might be going beyond the intended scope of the exercise.
- Originally i had a seperate method for calculating the date a year ago as i wanted to take leap years into account. However this proved unneccessary as AddYears 
  already takes this into account.
