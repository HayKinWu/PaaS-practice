#!/usr/bin/env python
# -*- coding: utf-8 -*-
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
import time

agile_url="http://10.67.44.188:7002/Agile/default/login-cms.jsp"
username="20825"
password="."

# Setup FireFox Autodownload to folder
profile = webdriver.FirefoxProfile()
profile.set_preference("browser.download.panel.shown",False)
profile.set_preference("browser.helperApps.neverAsk.openFile", "text/csv,application/vnd.ms-excel")
profile.set_preference("browser.helperApps.neverAsk.saveToDisk","text/csv,application/vnd.ms-excel")
profile.set_preference("browser.download.folderList", 2)
# Setup custom download dir
#profile.set_preference("browser.download.dir","/Users/allan/Desktop")



print "Opening FireFox ...."
driver = webdriver.Firefox(firefox_profile=profile)
# this is very very important
driver.implicitly_wait(10)

print "Open Agile website"
driver.get(agile_url)

print "Enter Username / Password"

driver.find_element_by_id("j_username").send_keys(username)
driver.find_element_by_id("j_password").send_keys(password)

print "Do Login"
driver.find_element_by_id("login").click()

print "Sleep 15 second"
time.sleep(15)

print "Sleep End"

for handle in driver.window_handles:
    driver.switch_to_window(handle)
    if driver.title.find("Welcome") != -1:
        break

print "Click - Personal Search"
driver.execute_script("javascript:YAHOO.widget.TreeView.getNode('searchTree',2).toggle()")
time.sleep(3)

print "Click - Get Deviation"
driver.execute_script("javascript:displayQuery('43987607','','false','','gST',13,43383315)")
time.sleep(10)

print "Download xls"
driver.execute_script("javascript:AGILE.util.ExportSearch({opcode:'exportQuery', xtraArgs:'&reportExportType=3'})")

print "Wait For Download Finish"
time.sleep(10)

print "Bye"
driver.quit()
