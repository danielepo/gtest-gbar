using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Guitar.Lib;
using Guitar.Lib.ViewModels;

namespace Guitar.Controls
{
    class TestTreeView : TreeView
    {
        private const string SUCCEEDED_IMG = "PASS";
        private const string FAILED_IMG = "FAIL";
        private const string NOTRUN_IMG = "NORN";
        private const string IGNORED_IMG = "IGNO";

        public TestListViewModel ViewModel;
        private Dictionary<ITest, TreeNode> _testNodes;
        private Dictionary<ITestCase, TreeNode> _caseNodes;
        private Dictionary<ITestSuite, TreeNode> _suiteNodes;

        public int TestCount { get; private set; }

        private delegate void UpdateImageDelegate(TreeNode node, string imageIdx);

        public TestTreeView() : base()
        {
            ViewModel = new TestListViewModel();
            ViewModel.PropertyChanged += ViewModelOnPropertyChanged;

            StateImageList = new ImageList();
            StateImageList.Images.Add(SUCCEEDED_IMG, Guitar.Properties.Resources.accept);
            StateImageList.Images.Add(FAILED_IMG, Guitar.Properties.Resources.exclamation);
            StateImageList.Images.Add(NOTRUN_IMG, Guitar.Properties.Resources.bullet_white);
            StateImageList.Images.Add(IGNORED_IMG, Guitar.Properties.Resources.error);

            this.NodeMouseDoubleClick += OnNodeMouseDoubleClick;

            _testNodes = new Dictionary<ITest, TreeNode>();
            _caseNodes = new Dictionary<ITestCase, TreeNode>();
            _suiteNodes = new Dictionary<ITestSuite, TreeNode>();

            TestCount = 0;
        }

        private void OnNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs treeNodeMouseClickEventArgs)
        {
            object tag = treeNodeMouseClickEventArgs.Node.Tag;
            if (tag is ITest || tag is ITestCase || tag is ITestSuite)
            {
                OnRunRequested(new RunRequestEventArgs(tag));
            }
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if(propertyChangedEventArgs.PropertyName == TestListViewModel.SuitesProperty)
            {
                RebuildTree();
            }
        }

        private void RebuildTree()
        {
            TestCount = 0;
            Nodes.Clear();

            TreeNode root = new TreeNode("Suites");

            foreach (var suite in ViewModel.Suites)
            {
                TreeNode suiteNode = new TreeNode(suite.Name);
                suiteNode.Tag = suite;
                suiteNode.StateImageKey = NOTRUN_IMG;

                foreach (var testCase in suite.TestCases)
                {
                    TreeNode caseNode = new TreeNode(testCase.Name);
                    caseNode.Tag = testCase;
                    caseNode.StateImageKey = NOTRUN_IMG;

                    foreach (var test in testCase.Tests)
                    {
                        TreeNode testNode = new TreeNode(test.Name);
                        testNode.Tag = test;
                        testNode.StateImageKey = NOTRUN_IMG;

                        test.TestCompleted += TestOnTestCompleted;

                        TestCount++;

                        _testNodes.Add(test, testNode);
                        caseNode.Nodes.Add(testNode);
                    }

                    testCase.ResultUpdated += OnResultUpdated;

                    _caseNodes.Add(testCase, caseNode);
                    suiteNode.Nodes.Add(caseNode);
                }

                suite.ResultUpdated += OnResultUpdated;

                _suiteNodes.Add(suite, suiteNode);
                root.Nodes.Add(suiteNode);
            }

            Nodes.Add(root);
        }

        private void OnResultUpdated(object sender, TestResult result)
        {
            ITestSuite suite = sender as ITestSuite;

            if(suite != null && _suiteNodes.ContainsKey(suite))
            {
                this.Invoke(new UpdateImageDelegate(UpdateNodeImage), _suiteNodes[suite], GetKey(result));
            }

            ITestCase cCase = sender as ITestCase;

            if(cCase != null && _caseNodes.ContainsKey(cCase))
            {
                this.Invoke(new UpdateImageDelegate(UpdateNodeImage), _caseNodes[cCase], GetKey(result));
            }
        }

        private void TestOnTestCompleted(ITest test, TestResult result)
        {
            if (_testNodes.ContainsKey(test))
            {
                this.Invoke(new UpdateImageDelegate(UpdateNodeImage), _testNodes[test], GetKey(result));
            }
        }

        private string GetKey(TestResult result)
        {
            if (result.Outcome == TestStatus.Passed)
            {
                return SUCCEEDED_IMG;
            }
            else if (result.Outcome == TestStatus.Failed)
            {
                return FAILED_IMG;
            }
            else if (result.Outcome == TestStatus.Ignored)
            {
                return IGNORED_IMG;
            }
            else
            {
                return NOTRUN_IMG;
            }
        }

        private void UpdateNodeImage(TreeNode node, string imageIdx)
        {
            node.StateImageKey = imageIdx;
        }


        public event EventHandler<RunRequestEventArgs> RunRequested;

        protected virtual void OnRunRequested(RunRequestEventArgs e)
        {
            EventHandler<RunRequestEventArgs> handler = RunRequested;
            if (handler != null) handler(this, e);
        }
    }
}
