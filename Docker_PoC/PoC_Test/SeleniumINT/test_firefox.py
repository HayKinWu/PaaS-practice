#!/usr/bin/env python
# -*- coding: utf-8 -*-
#!/usr/bin/env python
# -*- coding: utf-8 -*-
#!/usr/bin/env python
# -*- coding: utf-8 -*-
from selenium import webdriver
from selenium.webdriver.common.desired_capabilities import DesiredCapabilities

print ("--- run_test used Firefox webdriver start ---")

print ("connect to remote selenium server 10.67.37.24:4444")
driver = webdriver.Remote(command_executor="http://10.67.37.24:4444/wd/hub",
            desired_capabilities=webdriver.DesiredCapabilities.FIREFOX.copy())

if driver is None:
  print ("connect to remote selenium server 10.67.37.24:4444 fail")
  exit(-1)


driver.implicitly_wait(10)
driver.get("http://10.67.44.130")

element = driver.find_element_by_xpath('//html/body/div/table/tbody/tr')

content = element.text.strip()
print ("--------- Print content Begin ------------")
print (content)
print ("--------- Print content End -------------")
if content == "User ID":
  print ("Ya Test success")
else:
  print ("Test Fail -- " )
  
driver.get_screenshot_as_file('Test.png')


print ("%s %s -  Test done - will driver.close()" )
try:
    driver.close()
except:
    pass

print ("%s %s -  Test done - will driver.quit()" )
try:
    driver.quit()
except:
    pass

print ("%s %s -   All done. SUCCESS! - DONE driver.quit()" )
                                    
					   
############# run test_firefox.py in selenium docker container ####################