# Database Relationship Finder
This solution can find relationships between dabase tables.
![Database Relationships](https://lh3.googleusercontent.com/PAUfQIVytMpEw1BVfhV2azbySCbZQ5NkZUT4n1IJQ2qdmER4ihN8i_zJx_fTGtuMkjjLVL78AoZ1enwM1q8tghYSLHJ6lpwy3L1tmuJcek5CFuJEOshKkaB_HlH5Ud-oJ-hgi5uK3Z0Ht8XVGfOBKLhoC5U3r1jZqb6J4jC1kaG9vlSFVJs6oc7jYW3_dWGpOf0iYVo9L5J1K9dsrsqeTOWQTFh785ghMyowuJWTI8dwhKRs0g64zgVTJIADrFXR_QRoUsErNTtouMEXGlA82VdLn1DXUGn4JEi7Rghc_vFMkGsBGzmbYx_vJ3KF97e-3g2c0iw5XlSmjVPs599OL0cKft7Mgymb_sgw_ffa59TdQsMxoCCZqHORe2t5pW2kOsBxsaMamWC6uS8wpbpLGGnc8iDWtwxoXDb91cO6BDjluR_eBljuJKfapTrd32pqOSNj6IS2-qJ6RJlIi8RXQK5dtk-sf0DsHzVLVDOzqjplAH0w0M9nqFfSvhvDjVdBoM5VRwAhgs7S13__H0lAjci7sNF_GFCboB3NlTogEIexmoAuoYrsxridLtNXGxEyJhlOBHGXJYX7yylZrS8l0BLhpoUL0Lw5RTS0tBndS3YyHWMKPJ2tDoJXB6PZlSVoEI7w69QTyVY2bhlhP2zFo-8KclwETrlLyuNaFKb3WYoPiQVhwBZBIsEZCq33_mVB-RRQ9GYI1TS-AhrxNRMgIbau_7TwrLKNKZp3jGNMQzZH5BUnCKJq64eS6ckVTxO5QBQs8AiMUs87BCMe0GFqe1VoMfD0tjD_6_T-xzoGTvUyksKZcZIIOcNUv-rQ5JCj6E-n2ug-dMK1dlw9WID9t35QqzLEnv7L6U5u9-jO2y6xP_a-EVFcu3fbiYZrzI8MNBk4uUwJtIHiFO-byli3onk2FXp8xUDgMe5_37kaGhuEvOuh=w850-h313-no?authuser=0)

# How to use
There is a variable it named that "connectionString" in program.cs. You should change this with your connection string. There is a static sql command. This command works with MS-SQL. If you use another db, you should check this command and update it for your db. The command finds relationships between tables which have primary and foreign keys. You can see the result of the relationship table above.

# How it works
## Crate Relationship Tree
After the relationships table is found, primary tables, primary keys, foreign tables and foreign keys are determined. Primary tables are grouped because tables can be found more than once in relationship result list. After determination, next step is to identify relationships. There is a recursive function. It name is NodeCreator. We call this function with table list. This function checks the name of table and its relationships. If it has relationship, it checks foreign table has relationships or not. In this way, a relationship tree is created. 

![Database Relationships](https://lh3.googleusercontent.com/K-KiihcU2TQOgXI2YrgVaeXVs-2OXrqeeeFI4O68JbSrUNRw8kvOizDBW5br9Bd435bVoayzs0SBChN9-isytT_H3wUs6JWV9Sf2DObQqTHQ09rBeF4x6LVBVLTzreetEnV_kSm3rxOv9eAH_f_yOCSOdaE6O07F3x4UcTeHJhg4kwc5jSMRdnstRee5uYlpdW_UUOD4AgjZOB3zjicDRID4ZNybEgtAQD_DiDJjNPoleaq1jYAhoJjnecv_hreGMnWHsRdYO4GCy11I-RMq6xd0B5FXor_mEdAlbscFR0lAd0LwWcGZRYXXlFueAxOnzGXR0KG5BCO6yDvacEuJa6KkV7ErbHf0Ra_qUQP32602isuXBK-xUiOEh6tGTtGJY9zVazVH_XpGupzZwTRmWItK3MBHVcYWTSn_ms99dWhcXuzCjc--l6_eKdIYX_mqsJ5-W5q40QxZrix6KslZoHN_KQnytRiS1Bc7_GsnYwRCUujTFbxYvEVKjZTAGCJ0ZsmHiPQ6odUkYLC6KyGX3XufXTEz74rHWBZ_7Xv19gf92GTq7NFp4s-23ceT9kTpxLgykgmE0GNp7PrQZx2FsRk4XNNeKJZVz-F0xgawrGtsXyGD48E1tVigAiZkZLGrHShozOeKYUXqt816M5jAp71OgVERcmR3j1KsNTAWkXJeigbcDSdBSP8SibaW414TDhMjqj_7xeFqTlVzCzDQ9yUuMXNMODd3vW4NihFo_he0v05vRlgyBK4fXQBZJyifQJP52PaE2s0p95ongrXuOD1Y9L5dmUPs2ugekS2HdgmZGKVeCzGdzw4znxQnBH14KNIgxLiqNyUX9X0KjVlIc2anOCWRLKf5niDgKx3ehqifS3xdkJ4J5AjfGWENLgQ2L5-mNPe3ipr3C2BLJHI3lJUhJT7k9YjuQ1YOxUSfy9RpkrSr=w563-h687-no?authuser=0)

## Print Results
There is a recursive function for printing nodes. We gives our nodes to this function. If node have subnodes, this function calls itself for printing subnodes.

![Database Relationships](https://lh3.googleusercontent.com/gE2kfSM7jWXCvgtVQ2APjDDWO0HJmR_SqRX3HcmdbHAWClZoKnBo4mjODbayu8MOgkOR6_4daUZzXet8lTN2QmCBgkebf2T4JE7yHiIz3t7aWAeMwT_R6SfV7ENXs0ZST7CqfSVUsPoth2fDHtb-g-l767pVe5npeEHMaUG6mcxt0IlT-Q_Mh7F996HHLqbtZHkwIH9CPHrPXWKF8smHCcmpsWAsV9sGbUno7bLDIAbTxjcLslkfEywWwsdpGlpkP57JNhKWdYiKNKlE5_sAfD-3CEH79FkXIOpbGu2Jg7hWaJXh_3b0jCb6DHpHGVOIresW1Afym5dvj7ogbzmqK0YpGNG7ijx4j1du-pDbM8qqzCWejmhB460nMj5XPgB_ohuS1Ade4y5kFxXQRiTVrQNk-iecYgtwoTnDBXWw522qiFc2gSbuAWc8pv8_4ywLzeR0JOMgpImZj1JsxCePqDgRvzSZhBEdOeJI6jstPLM24gr1TZ91zo39heMQW2X4xpalfD82EvBVaaO5ZKUP7PFKCVgudCeuSM5-Npnpe2V7kAMRxIpPGksc52xaLZS346HdNWzy1gvXFy0E2USqP2yshmvnWhTL7sF_YXCLei8SjKxrgzt8Y_99Q6MDlKlJg5TOO1oSP3xQFewprnVMf1QJO5OqAzs6TXt3Fh1fkCXlIBSQgcLCBFClO8nWLPRqJLY1zIGOBUn9NiE_LErdvx6-qR6KkETnhcyVVQyQ-koWf71lXHZafaYX94Nm8jhqVq3w-VNmPUrz5LhX3vX1bovJ4zdltNlTz8VNK550tqPUxGvL2VVOQ5oPh3NivlqUo-_YizMwqBZzLotbRWaf_E7-Dgalx6hvGQxPpeQo3wgIHM0xAmg5JQ0ZXKyLPUhXogmG7m5HRLcXOhnqKZprliZPZ_j4e1RW8GSY6Ed7lixUFcVu=w757-h435-no?authuser=0)
